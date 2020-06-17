
#include "StdAfx.h"
#include "NMEAParser.h"


CNMEAParser::CNMEAParser()
{
	_state = STATE_SOM;
	_commandCount = 0;

	Reset();
}

CNMEAParser::~CNMEAParser()
{
}

bool CNMEAParser::ParseBuffer(char *buff, int len)
{
	// NMEA 문법에 따라 buff를 파싱한다.

	for (int i = 0; i < len; i++) {
		ProcessNMEA(buff[i]);
	}
	return true;
}

void CNMEAParser::ProcessNMEA(char data)
{
	// NMEA 문장은 일반적으로 다음과 같이 생겼다.
	//
	//	$CMD,DDDD,DDDD,....DD*CS<CR><LF>
	//
	//		'$'			HEX 24 Start of sentence
	//		'CMD'		Address/NMEA command
	//		',DDDD'		Zero or more data fields
	//		'*CS'		Checksum field
	//		<CR><LF>	Hex 0d 0A End of sentence
	//
	// EX: $GPGSA,A,3,09,21,18,26,22,12,05,24,29,,,,1.8,0.9,1.5*3A

	switch(_state) {
	case STATE_SOM :	// Search for start of message '$'
		if(data == '$') {
			_checksum = 0;			// reset checksum
			_index = 0;				// reset index
			_state = STATE_CMD;
		}
		break;
	case STATE_CMD :	// Retrieve command (NMEA Address)
		if(data != ',' && data != '*') {
			_command[_index++] = data;
			_checksum ^= (unsigned char)data;

			// Check for command overflow
			if(_index >= MAX_CMD_LEN) {
				_state = STATE_SOM;
			}
		}
		else {
			_command[_index] = '\0';	// terminate command
			_checksum ^= (unsigned char)data;
			_index = 0;
			_state = STATE_DATA;		// goto get data state
		}
		break;
	case STATE_DATA :	// Store data and check for end of sentence or checksum flag
		if(data == '*') { // checksum flag?
			_data[_index] = '\0';
			_state = STATE_CHECKSUM;
			_index = 0;
			_receivedChecksum = 0;
		}
		else { // no checksum flag, store data
			// Check for end of sentence with no checksum
			if(data == '\r') {
				_data[_index] = '\0';
				ProcessCommand(_command, _data);

				_state = STATE_SOM;
				return;
			}

			// Store data and calculate checksum
			_checksum ^= (unsigned char)data;
			_data[_index] = data;
			if (++_index >= MAX_DATA_LEN) { // Check for buffer overflow
				_state = STATE_SOM;
			}
		}
		break;
	case STATE_CHECKSUM :
		_receivedChecksum <<= 4;
		_receivedChecksum += ( (data - '0') <= 9) ? (data - '0') : (data - 'A' + 10);
		_index++;

		if(_index == 2) {
			if (_checksum == _receivedChecksum) {
				ProcessCommand(_command, _data);
			}
			_state = STATE_SOM;
		}
		break;

	default : 
		_state = STATE_SOM;
		break;
	}
}

bool CNMEAParser::ProcessCommand(char *pCommand, char *data)
{
	     if (!strcmp((char *)pCommand, "GPGGA"))	ProcessGPGGA(data);
	else if (!strcmp((char *)pCommand, "GPGSA"))	ProcessGPGSA(data);
	else if (!strcmp((char *)pCommand, "GPGSV"))	ProcessGPGSV(data);
	else if (!strcmp((char *)pCommand, "GPRMB"))	ProcessGPRMB(data);
	else if (!strcmp((char *)pCommand, "GPRMC"))	ProcessGPRMC(data);
	else if (!strcmp((char *)pCommand, "GPZDA"))	ProcessGPZDA(data);
	else if (!strcmp((char *)pCommand, "GPVTG"))	ProcessGPVTG(data);

	_commandCount++;
	return true;
}

bool CNMEAParser::GetFields (char *data, char **fields, int maxFieldLen)
{
	int nField = 0;
	fields[nField++] = data;

	for (int i = 0; data[i]; i++) {
		if (data[i] == ',') {
			data[i] = '\0';
			fields[nField++] = &data[i+1];
		}
	}

	for ( ; nField < maxFieldLen; nField++) {
		fields[nField] = (char *)"";
	}
	return true;
}

char CNMEAParser::GetFieldChar (char *fieldData, char defaultValue)
{
	if (fieldData[0]) {
		return fieldData[0];
	}
	return defaultValue;
}

int CNMEAParser::GetFieldInt (char *fieldData, int defaultValue)
{
	if (fieldData[0]) {
		return atoi((char *)fieldData);
	}
	return defaultValue;
}

double CNMEAParser::GetFieldFloat (char *fieldData, double defaultValue)
{
	if (fieldData[0]) {
		return atof((char *)fieldData);
	}
	return defaultValue;
}

double CNMEAParser::GetFieldLatitude (char *fieldData, double defaultValue)
{
	if (strlen(fieldData) > 2) {
		double latitude = atof((char *)fieldData+2) / 60.0;
		fieldData[2] = '\0';
		latitude += atof((char *)fieldData);
		return latitude;
	}
	return defaultValue;
}

double CNMEAParser::GetFieldLongitude (char *fieldData, double defaultValue)
{
	if (strlen(fieldData) > 3) {
		double longitude = atof((char *)fieldData+3) / 60.0;
		fieldData[3] = '\0';
		longitude += atof((char *)fieldData);
		return longitude;
	}
	return defaultValue;
}

void CNMEAParser::GetFieldString (char *value, char *fieldData, char *defaultValue)
{
	if (fieldData[0]) {
		strcpy(value, (char *)fieldData);
	}
	else {
		strcpy(value, defaultValue);
	}
}

void CNMEAParser::GetFieldDate (char *fieldData, int &year, char &month, char &day)
{
	if (fieldData[0]) {
		char buff[10];

		// Day
		buff[0] = fieldData[0];
		buff[1] = fieldData[1];
		buff[2] = '\0';
		day = atoi(buff);

		// Month
		buff[0] = fieldData[2];
		buff[1] = fieldData[3];
		buff[2] = '\0';
		month = atoi(buff);

		// Year (Only two digits. I wonder why?)
		buff[0] = fieldData[4];
		buff[1] = fieldData[5];
		buff[2] = '\0';
		year = 2000 + atoi(buff);
	}
}

void CNMEAParser::GetFieldTime (char *fieldData, char &hour, char &minute, double &second)
{
	if (fieldData[0]) {
		char buff[10];

		// Hour
		buff[0] = fieldData[0];
		buff[1] = fieldData[1];
		buff[2] = '\0';
		hour = atoi(buff);

		// minute
		buff[0] = fieldData[2];
		buff[1] = fieldData[3];
		buff[2] = '\0';
		minute = atoi(buff);

		// Second
		//buff[0] = fieldData[4];
		//buff[1] = fieldData[5];
		//buff[2] = '\0';
		//second = atoi(buff);
		second = atof((char *)fieldData+4);
	}
}

void CNMEAParser::Reset()
{
	// 모든 변수들을 초기화 한다.

	// GPGGA Data
	_GGAHour = 0;					//
	_GGAMinute = 0;					//
	_GGASecond = 0.0;				//
	_GGALatitude = 0.0;				// < 0 = South, > 0 = North 
	_GGALongitude = 0.0;				// < 0 = West, > 0 = East
	_GGAGPSQuality = 0;				// 0 = fix not available, 1 = GPS sps mode, 2 = Differential GPS, SPS mode, fix valid, 3 = GPS PPS mode, fix valid
	_GGANumOfSatsInUse = 0;			//
	_GGAHDOP = 0.0;					//
	_GGAAltitude = 0.0;				// Altitude: mean-sea-level (geoid) meters
	_GGACount = 0;					//
	_GGAOldVSpeedSeconds = 0;			//
	_GGAOldVSpeedAlt = 0.0;			//
	_GGAVertSpeed = 0.0;				//

	// GPGSA
	_GSAMode = 'M';					// M = manual, A = automatic 2D/3D
	_GSAFixMode = 1;					// 1 = fix not available, 2 = 2D, 3 = 3D
	for(int i = 0; i < MAX_CHAN; i++) {
		_GSASatsInSolution[i] = 0;	// ID of sats in solution
	}
	_GSAPDOP = 0.0;					//
	_GSAHDOP = 0.0;					//
	_GSAVDOP = 0.0;					//
	_GSACount = 0;					//

	// GPGSV
	_GSVTotalNumOfMsg = 0;			//
	_GSVTotalNumSatsInView = 0;		//
	for(int i = 0; i < MAX_CHAN; i++) {
		m_GSVSatInfo[i]._Azimuth = 0;
		m_GSVSatInfo[i]._Elevation = 0;
		m_GSVSatInfo[i]._PRN = 0;
		m_GSVSatInfo[i]._SignalQuality = 0;
		m_GSVSatInfo[i]._UsedInSolution = false;
	}
	_GSVCount = 0;

	// GPRMB
	_RMBDataStatus = 'V';			// A = data valid, V = navigation receiver warning
	_RMBCrosstrackError = 0.0;		// nautical miles
	_RMBDirectionToSteer = '?';		// L/R
	_RMBOriginWaypoint[0] = '\0';	// Origin Waypoint ID
	_RMBDestWaypoint[0] = '\0';	// Destination waypoint ID
	_RMBDestLatitude = 0.0;			// destination waypoint latitude
	_RMBDestLongitude = 0.0;			// destination waypoint longitude
	_RMBRangeToDest = 0.0;			// Range to destination nautical mi
	_RMBBearingToDest = 0.0;			// Bearing to destination, degrees true
	_RMBDestClosingVelocity = 0.0;	// Destination closing velocity, knots
	_RMBArrivalStatus = 'V';			// A = arrival circle entered, V = not entered
	_RMBCount = 0;					//

	// GPRMC
	_RMCHour = 0;					//
	_RMCMinute = 0;					//
	_RMCSecond = 0;					//
	_RMCDataValid = 'V';				// A = Data valid, V = navigation rx warning
	_RMCLatitude = 0.0;				// current latitude
	_RMCLongitude = 0.0;				// current longitude
	_RMCGroundSpeed = 0.0;			// speed over ground, knots
	_RMCCourse = 0.0;					// course over ground, degrees true
	_RMCDay = 1;						//
	_RMCMonth = 1;					//
	_RMCYear = 2000;					//
	_RMCMagVar = 0.0;					// magnitic variation, degrees East(+)/West(-)
	_RMCCount = 0;					//

	// GPZDA
	_ZDAHour = 0;					//
	_ZDAMinute = 0;					//
	_ZDASecond = 0;					//
	_ZDADay = 1;						// 1 - 31
	_ZDAMonth = 1;					// 1 - 12
	_ZDAYear = 2000;					//
	_ZDALocalZoneHour = 0;			// 0 to +/- 13
	_ZDALocalZoneMinute = 0;			// 0 - 59
	_ZDACount = 0;					//

	// GPVTG
	_TrueCourse = 0;					// 진침로
	_CompaseCourse = 0;				// 나침로
	_Kont = 0;
	_Km = 0;
	_VTGCount = 0;					//
}

bool CNMEAParser::IsSatUsedInSolution(int satID)
{
	// Check to see if supplied satellite ID is used in the GPS solution.

	if (satID) {
		for (int i = 0; i < 12; i++) {
			if(satID == _GSASatsInSolution[i]) {
				return true;
			}
		}
	}
	return false;
}

void CNMEAParser::ProcessGPGGA(char *data)
{
	/*
	-----------------------------------------------------------------------------
	Name					Example		Unit	Description
	-----------------------------------------------------------------------------
	Message ID				$GPGGA		GGA		protocol header
	UTC Time				161229.487			hhmmss.sss
	Latitude				3723.2475			ddmm.mmmm
	N/S Indicator			N					N=north or S=south
	Longitude				12158.3416			dddmm.mmmm
	E/W Indicator			W					E=east or W=west
	Position Fix Indicator	1					See Table 1-4
	Satellites Used			07					Range 0 to 12
	HDOP					1.0					Horizontal Dilution of Precision
	MSL Altitude			9.0			meters	
	Units					M			meters	
	Geoid Separation					meters	
	Units					M			meters	
	Age of Diff. Corr					second	Null fields when DGPS is not used
	Diff. Ref. Station ID	0000		
	Checksum				*18		
	<CR><LF>									End of message termination
	-----------------------------------------------------------------------------
	[$GPGGA] $GPGGA,084816.000,3728.6289,N,12652.8449,E,1,09,0.9,89.4,M,19.3,M,,0000*69
	-----------------------------------------------------------------------------
	*/

	char *fields[MAX_FIELD];

	GetFields (data, fields, MAX_FIELD);

	GetFieldTime (fields[0], _GGAHour, _GGAMinute, _GGASecond);

	_GGALatitude = GetFieldLatitude (fields[1], _GGALatitude);
	if (GetFieldChar (fields[2], ' ') == 'S') _GGALatitude *= -1;

	_GGALongitude = GetFieldLongitude (fields[3], _GGALongitude);
	if (GetFieldChar (fields[4], ' ') == 'W') _GGALongitude *= -1;

	_GGAGPSQuality     = GetFieldChar (fields[5], '0') - '0';
	_GGANumOfSatsInUse = GetFieldInt (fields[6], 0);
	_GGAHDOP           = GetFieldFloat (fields[7], 0.);
	_GGAAltitude       = GetFieldFloat (fields[8], 0.);

	// Durive vertical speed (bonus)
	int nSeconds = (int)_GGAMinute * 60 + (int)_GGASecond;
	if(nSeconds > _GGAOldVSpeedSeconds) {
		double dDiff = (double)(_GGAOldVSpeedSeconds-nSeconds);
		double dVal = dDiff/60.0;
		if(dVal != 0.0) {
			_GGAVertSpeed = (_GGAOldVSpeedAlt - _GGAAltitude) / dVal;
		}
	}
	_GGAOldVSpeedAlt = _GGAAltitude;
	_GGAOldVSpeedSeconds = nSeconds;

	_GGACount++;
}

void CNMEAParser::ProcessGPGSA(char *data)
{
	/*
	-----------------------------------------------------------------------------
	Name					Example		Unit	Description
	-----------------------------------------------------------------------------
	Message ID				$GPGSA				GSA protocol header
	Mode1					A					See Table 1-7
	Mode2					3					See Table 1-8
	Satellite Used1			07					Sv on Channel 1
	Satellite Used1			02					Sv on Channel 2
	….			….
	Satellite Used1								Sv on Channel 12
	PDOP					1.8		
	HDOP					1.0		
	VDOP					1.5		
	Checksum				*33		
	<CR><LF>									End of message termination
	-----------------------------------------------------------------------------
	[$GPGSA] $GPGSA,A,3,09,21,18,26,22,12,05,24,29,,,,1.8,0.9,1.5*3A
	-----------------------------------------------------------------------------
	*/
	char *fields[MAX_FIELD];

	GetFields (data, fields, MAX_FIELD);

	_GSAMode = GetFieldChar (fields[0], ' ');
	_GSAFixMode = GetFieldChar (fields[1], '0') - '0';

	// Active satellites
	for (int i = 0; i < 12; i++) {
		fields[2+i][2] = '\0';
		_GSASatsInSolution[i] = GetFieldInt (fields[2+i], 0);
	}

	_GSAPDOP = GetFieldFloat (fields[14], 0.);
	_GSAHDOP = GetFieldFloat (fields[15], 0.);
	_GSAVDOP = GetFieldFloat (fields[16], 0.);

	_GSACount++;
}

void CNMEAParser::ProcessGPGSV(char *data)
{
	/*
	-----------------------------------------------------------------------------
	Name					Example		Unit	Description
	-----------------------------------------------------------------------------
	Message ID				$GPGSA				GSA protocol header
	Number of Message1		2					Range 1 to 3
	Message Number1			1					Range 1 to 3
	Satellite in View		07			
	Satellite ID			07					Channel 1 (Range 1 to 32)
	Elevation				79			degrees	Channel 1 (Maximum 90) 
	Azimuth					048			degrees	Channel 1 (True, Range 0 to 359)
	SNR (C/No)				42			dBHz	Range 0 to 99, null when not tracking
	….			….
	Satellite ID			27			Channel 4 (Range 1 to 32)
	Elevation				27			degrees	Channel 4 (Maximum 90)
	Azimuth					138			degrees	Channel 4 (True, Range 0 to 359)
	SNR (C/No)				42			dBHz	Range 0 to 99, null when not tracking
	Checksum				*71		
	<CR><LF>									End of message termination
	-----------------------------------------------------------------------------
	[$GPGSV] $GPGSV,3,1,12,09,81,154,45,18,56,317,46,21,45,233,45,26,33,059,44*7D
			 $GPGSV,3,2,12,24,26,189,42,29,24,066,40,22,23,310,44,12,13,155,41*70
			 $GPGSV,3,3,12,05,11,166,38,10,04,126,36,14,02,266,34,28,02,032,35*7D
	-----------------------------------------------------------------------------
	                    SAT1          SAT2          SAT3          SAT4
	-----------------------------------------------------------------------------
	$GPGSV,3,1,12, 09,81,154,45, 18,56,317,46, 21,45,233,45, 26,33,059,44 *7D
	$GPGSV,3,2,12, 24,26,189,42, 29,24,066,40, 22,23,310,44, 12,13,155,41 *70
	$GPGSV,3,3,12, 05,11,166,38, 10,04,126,36, 14,02,266,34, 28,02,032,35 *7D
	-----------------------------------------------------------------------------
	CONVERT
	-----------------------------------------------------------------------------
	[szHeader] $GPGSV,3,1,12,
	[$GPGSV] 09,81,154,45, 18,56,317,46, 21,45,233,45, 26,33,059,44
			 24,26,189,42, 29,24,066,40, 22,23,310,44, 12,13,155,41
			 05,11,166,38, 10,04,126,36, 14,02,266,34, 28,02,032,35
	-----------------------------------------------------------------------------
	*/

	char *fields[MAX_FIELD];

	GetFields (data, fields, MAX_FIELD);

	// Total number of messages
	int totalNumOfMsg = GetFieldInt (fields[0], -1);

	// Make sure that the totalNumOfMsg is valid. This is used to
	// calculate indexes into an array. I've seen corrept NMEA strings
	// with no checksum set this to large values.
	if(totalNumOfMsg > 9 || totalNumOfMsg < 0) return; 

	if(totalNumOfMsg < 1 || totalNumOfMsg*4 >= MAX_CHAN) {
		return;
	}

	// message number
	int msgNum = GetFieldInt (fields[1], -1);

	// Make sure that the message number is valid. This is used to
	// calculate indexes into an array
	if(msgNum > 9 || msgNum < 0) return; 

	// Total satellites in view
	_GSVTotalNumSatsInView = GetFieldInt (fields[2], _GSVTotalNumSatsInView);

	// Satelite data
	for(int i = 0; i < 4; i++) {
		// Satellite ID
		m_GSVSatInfo[i+(msgNum-1)*4]._PRN = GetFieldInt (fields[3] + 4*i, 0);
		m_GSVSatInfo[i+(msgNum-1)*4]._Elevation = GetFieldInt (fields[4] + 4*i, 0);
		m_GSVSatInfo[i+(msgNum-1)*4]._Azimuth = GetFieldInt (fields[5] + 4*i, 0);
		m_GSVSatInfo[i+(msgNum-1)*4]._SignalQuality = GetFieldInt (fields[6] + 4*i, 0);

		// Update "used in solution" (_UsedInSolution) flag. This is base
		// on the GSA message and is an added convenience for post processing
		m_GSVSatInfo[i+(msgNum-1)*4]._UsedInSolution = IsSatUsedInSolution(m_GSVSatInfo[i+(msgNum-1)*4]._PRN);
	}

	_GSVCount++;
}

void CNMEAParser::ProcessGPRMB(char *data)
{
	char *fields[MAX_FIELD];

	GetFields (data, fields, MAX_FIELD);

	_RMBDataStatus       = GetFieldChar (fields[0], 'V');
	_RMBCrosstrackError  = GetFieldFloat (fields[1], 0.);
	_RMBDirectionToSteer = GetFieldChar (fields[2], '?');

	GetFieldString(_RMBOriginWaypoint, fields[3], "");
	GetFieldString(_RMBDestWaypoint, fields[4], "");

	_RMBDestLatitude = GetFieldLatitude (fields[5], _RMBDestLatitude);
	if (GetFieldChar (fields[6], ' ') == 'S') _RMBDestLatitude *= -1;

	_RMBDestLongitude = GetFieldLongitude (fields[7], _RMBDestLongitude);
	if (GetFieldChar (fields[8], ' ') == 'W') _RMBDestLongitude *= -1;

	// Range to destination nautical mi
	_RMBRangeToDest = GetFieldFloat (fields[9], 0.);
	// Bearing to destination degrees true
	_RMBBearingToDest = GetFieldFloat (fields[10], 0.);
	_RMBDestClosingVelocity = GetFieldFloat (fields[11], 0.);
	_RMBArrivalStatus = GetFieldChar (fields[12], 'V');

	_RMBCount++;
}

void CNMEAParser::ProcessGPRMC(char *data)
{
	/*
	-----------------------------------------------------------------------------
	Name					Example		Unit	Description
	-----------------------------------------------------------------------------
	Message ID				$GPGSA				RMC protocol header
	UTC Time				161229.487			hhmmss.sss
	Status	A									A=data valid or V=data not valid
	Latitude				3723.2475			ddmm.mmmm
	N/S Indicator			N					N=north, S=south
	Longitude				12158.3416			ddd mm.mmmm
	E/W Indicator			W					E=east or W=west
	Speed Over Ground		0.13		knots	
	Course Over Ground		309.62		degrees	true
	Date					120598				ddmmyy
	Magnetic Variation					degrees	E=east or W=west
	Mode					A					A=Autonomous, D=DGPS, E=DR
	Checksum	*10		
	<CR><LF>									End of message termination
	-----------------------------------------------------------------------------
	*/

	char *fields[MAX_FIELD];

	GetFields (data, fields, MAX_FIELD);

	GetFieldTime (fields[0], _RMCHour, _RMCMinute, _RMCSecond);
	_RMCDataValid = GetFieldChar (fields[1], 'V');

	_RMCLatitude = GetFieldLatitude (fields[2], _RMCLatitude);
	if (GetFieldChar (fields[3], ' ') == 'S') _RMCLatitude *= -1;

	_RMCLongitude = GetFieldLongitude (fields[4], _RMCLongitude);
	if (GetFieldChar (fields[5], ' ') == 'W') _RMCLongitude *= -1;

	// Ground speed
	_RMCGroundSpeed = GetFieldFloat (fields[6], 0.);
	// course over ground, degrees true
	_RMCCourse = GetFieldFloat (fields[7], 0.);

	GetFieldDate (fields[8], _RMCYear, _RMCMonth, _RMCDay);

	// course over ground, degrees true
	_RMCMagVar = GetFieldFloat (fields[9], 0.);
	if (GetFieldChar (fields[10], ' ') == 'W') _RMCMagVar *= -1;

	_RMCCount++;
}

void CNMEAParser::ProcessGPZDA(char *data)
{
	/*
	-----------------------------------------------------------------------------
	Name					Example		Unit	Description
	-----------------------------------------------------------------------------
	Message ID				$GPVTG				VTG protocol header
	UTC time				181813				Either using valid IONO/UTC or estimated from default leap seconds
	Day						14					01 to 31
	Month					10					01 to 12
	Year					2003				1980 to 2079
	Local zone hour			00			knots	offset from UTC (set to 00)
	Local zone minutes		00					offset from UTC (set to 00)
	Checksum			
	<CR><LF>									End of message termination
	-----------------------------------------------------------------------------
	*/

	char *fields[MAX_FIELD];

	GetFields (data, fields, MAX_FIELD);

	GetFieldTime (fields[0], _ZDAHour, _ZDAMinute, _ZDASecond);

	_ZDADay   = GetFieldInt (fields[1], 1);
	_ZDAMonth = GetFieldInt (fields[2], 1);
	_ZDAYear  = GetFieldInt (fields[3], 1);

	_ZDALocalZoneHour   = GetFieldInt (fields[4], 0);
	_ZDALocalZoneMinute = GetFieldInt (fields[5], 0);

	_ZDACount++;
}

void CNMEAParser::ProcessGPVTG(char *data)
{
	/*
	-----------------------------------------------------------------------------
	Name					Example		Unit	Description
	-----------------------------------------------------------------------------
	Message ID				$GPVTG		VTG		protocol header
	Course					309.62		degrees	Measured heading
	Reference				T			true
	Course								degrees	Measured heading
	Reference				M					Magnetic
	Speed					0.13		knots	Measured horizontal speed
	Units					N			Knots
	Speed					0.2			km/hr	Measured horizontal speed
	Units					K					Kilometers per hour
	Mode					A					A=Autonomous, D=DPGS, E=DR
	Checksum				*23		
	<CR><LF>									End of message termination
	-----------------------------------------------------------------------------
	// Example: $GPVTG,139.66,T,,M,0.12,N,0.2,K,A*07
	*/

	char *fields[MAX_FIELD];

	GetFields (data, fields, MAX_FIELD);

	_TrueCourse    = GetFieldFloat (fields[0], 0.);
	_CompaseCourse = GetFieldFloat (fields[2], 0.);
	_Kont          = GetFieldFloat (fields[4], 0.);
	_Km            = GetFieldFloat (fields[6], 0.);

	_VTGCount++;
}
