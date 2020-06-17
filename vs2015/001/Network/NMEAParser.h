
#pragma once

enum STATE {
	STATE_SOM =				0,			// Search for start of message
	STATE_CMD,							// Get command
	STATE_DATA,							// Get data
	STATE_CHECKSUM,						// Get checksum character
};

#define MAX_CMD_LEN				8		// maximum command length (NMEA address)
#define MAX_DATA_LEN			256		// maximum data length
#define MAX_CHAN				36		// maximum number of channels
#define WAYPOINT_ID_LEN			32		// waypoint max string len

#define MAX_FIELD				25

class CNPSatInfo
{
public:
	int	_PRN;							//
	int	_SignalQuality;					//
	bool	_UsedInSolution;			//
	int	_Azimuth;						//
	int	_Elevation;						//
};

class CNMEAParser  
{
public:
	void Reset();
	bool ParseBuffer(char *buff, int len);
	
	CNMEAParser();
	virtual ~CNMEAParser();

public:
	long _commandCount;					// number of NMEA commands received (processed or not processed)

	// GPGGA Data
	char _GGAHour;						//
	char _GGAMinute;					//
	double _GGASecond;	
	double _GGALatitude;				// < 0 = South, > 0 = North
	double _GGALongitude;				// < 0 = West, > 0 = East
	char _GGAGPSQuality;				// 0 = fix not available, 1 = GPS sps mode, 2 = Differential GPS, SPS mode, fix valid, 3 = GPS PPS mode, fix valid
	char _GGANumOfSatsInUse;			//
	double _GGAHDOP;					//
	double _GGAAltitude;				// Altitude: mean-sea-level (geoid) meters
	long _GGACount;						//
	int _GGAOldVSpeedSeconds;			//
	double _GGAOldVSpeedAlt;			//
	double _GGAVertSpeed;				//

	// GPGSA
	char _GSAMode;						// M = manual, A = automatic 2D/3D
	char _GSAFixMode;					// 1 = fix not available, 2 = 2D, 3 = 3D
	int _GSASatsInSolution[MAX_CHAN];	// ID of sats in solution
	double _GSAPDOP;					//
	double _GSAHDOP;					//
	double _GSAVDOP;					//
	long _GSACount;						//

	// GPGSV
	char _GSVTotalNumOfMsg;				//
	int _GSVTotalNumSatsInView;			//
	CNPSatInfo m_GSVSatInfo[MAX_CHAN];	//
	long _GSVCount;						//

	// GPRMB
	char _RMBDataStatus;				// A = data valid, V = navigation receiver warning
	double _RMBCrosstrackError;			// nautical miles
	char _RMBDirectionToSteer;			// L/R
	char _RMBOriginWaypoint[WAYPOINT_ID_LEN]; // Origin Waypoint ID
	char _RMBDestWaypoint[WAYPOINT_ID_LEN]; // Destination waypoint ID
	double _RMBDestLatitude;			// destination waypoint latitude
	double _RMBDestLongitude;			// destination waypoint longitude
	double _RMBRangeToDest;				// Range to destination nautical mi
	double _RMBBearingToDest;			// Bearing to destination, degrees true
	double _RMBDestClosingVelocity;		// Destination closing velocity, knots
	char _RMBArrivalStatus;				// A = arrival circle entered, V = not entered
	long _RMBCount;						//

	// GPRMC
	char _RMCHour;						//
	char _RMCMinute;					//
	double _RMCSecond;					//
	char _RMCDataValid;					// A = Data valid, V = navigation rx warning
	double _RMCLatitude;				// current latitude
	double _RMCLongitude;				// current longitude
	double _RMCGroundSpeed;				// speed over ground, knots
	double _RMCCourse;					// course over ground, degrees true
	char _RMCDay;						//
	char _RMCMonth;						//
	int _RMCYear;						//
	double _RMCMagVar;					// magnitic variation, degrees East(+)/West(-)
	long _RMCCount;						//

	// GPZDA
	char _ZDAHour;						//
	char _ZDAMinute;					//
	double _ZDASecond;					//
	char _ZDADay;						// 1 - 31
	char _ZDAMonth;						// 1 - 12
	int _ZDAYear;						//
	char _ZDALocalZoneHour;				// 0 to +/- 13
	char _ZDALocalZoneMinute;			// 0 - 59
	long _ZDACount;						//

	// GPVTG
	double _TrueCourse;					// heading (degree), 진침로
	double _CompaseCourse;				// heading (degree), 나침로
	double _Kont;						// horizontal speed (knot)
	double _Km;							// horizontal speed (km/hr)
	long _VTGCount;						//

private:
	void ProcessGPZDA(char *data);
	void ProcessGPRMC(char *data);
	void ProcessGPRMB(char *data);
	void ProcessGPGSV(char *data);
	void ProcessGPGSA(char *data);
	void ProcessGPGGA(char *data);
	void ProcessGPVTG(char *data);

	bool IsSatUsedInSolution(int satID);
	bool GetFields (char *data, char **fields, int maxFieldLen);
	bool ProcessCommand(char *pCommand, char *data);
	void ProcessNMEA(char data);

	char GetFieldChar (char *fieldData, char defaultValue);
	int GetFieldInt (char *fieldData, int defaultValue);
	double GetFieldFloat (char *fieldData, double defaultValue);
	double GetFieldLatitude (char *fieldData, double defaultValue);
	double GetFieldLongitude (char *fieldData, double defaultValue);
	void GetFieldString (char *value, char *fieldData, char *defaultValue);
	void GetFieldDate (char *fieldData, int &year, char &month, char &day);
	void GetFieldTime (char *fieldData, char &hour, char &minute, double &second);

private:
	STATE _state;					// Current state protocol parser is in
	unsigned char _checksum;		// Calculated NMEA sentence checksum
	unsigned char _receivedChecksum;// Received NMEA sentence checksum (if exists)
	int _index;						// Index used for command and data, checksum
	char _command[MAX_CMD_LEN];		// NMEA command
	char _data[MAX_DATA_LEN];		// NMEA data
};
