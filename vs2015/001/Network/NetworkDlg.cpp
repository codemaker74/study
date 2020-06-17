
// NetworkDlg.cpp : ���� ����
//

#include "stdafx.h"
#include "Network.h"
#include "NetworkDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// ���� ���α׷� ������ ���Ǵ� CAboutDlg ��ȭ �����Դϴ�.

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// ��ȭ ���� �������Դϴ�.
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_ABOUTBOX };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV �����Դϴ�.

// �����Դϴ�.
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(IDD_ABOUTBOX)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// CNetworkDlg ��ȭ ����



CNetworkDlg::CNetworkDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(IDD_NETWORK_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CNetworkDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_EDIT_LOG, m_ctrlEditLog);
}

BEGIN_MESSAGE_MAP(CNetworkDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BTN_UDP, &CNetworkDlg::OnBnClickedBtnUdp)
	ON_MESSAGE(WM_MYCLOSE,   &CNetworkDlg::OnThreadClosed)
	ON_MESSAGE(WM_MYRECEIVE, &CNetworkDlg::OnReceive)
	ON_BN_CLICKED(IDC_BTN_RS232, &CNetworkDlg::OnBnClickedBtnRs232)
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_BTN_DUMP, &CNetworkDlg::OnBnClickedBtnDump)
	ON_BN_CLICKED(IDC_RS422_ECHO, &CNetworkDlg::OnBnClickedRs422Echo)
END_MESSAGE_MAP()


// CNetworkDlg �޽��� ó����

BOOL CNetworkDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// �ý��� �޴��� "����..." �޴� �׸��� �߰��մϴ�.

	// IDM_ABOUTBOX�� �ý��� ��� ������ �־�� �մϴ�.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// �� ��ȭ ������ �������� �����մϴ�.  ���� ���α׷��� �� â�� ��ȭ ���ڰ� �ƴ� ��쿡��
	//  �����ӿ�ũ�� �� �۾��� �ڵ����� �����մϴ�.
	SetIcon(m_hIcon, TRUE);			// ū �������� �����մϴ�.
	SetIcon(m_hIcon, FALSE);		// ���� �������� �����մϴ�.

	// TODO: ���⿡ �߰� �ʱ�ȭ �۾��� �߰��մϴ�.

	//Set window & eidt_font
	ShowWindow(SW_SHOWMAXIMIZED);
	CFont m_Font;
	m_Font.CreatePointFont(100, _T("Consolas")); //Courier, Fixedsys, Consolas, Calibri
	GetDlgItem(IDC_EDIT_LOG)->SetFont(&m_Font);

	//Load config.ini
	TCHAR pValue[100];
	CString dafaultstr = _T("");
	CString strExePath;
	GetModuleFileName(NULL, strExePath.GetBuffer(MAX_PATH), MAX_PATH);
	strExePath.ReleaseBuffer();
	m_pathConfig.Format(_T("%s\\config.ini"), strExePath.Left(strExePath.ReverseFind('\\') + 1));
	if (PathFileExists(m_pathConfig) == FALSE) {
		AfxMessageBox(_T("Not found! ") + m_pathConfig);
		::PostQuitMessage(WM_QUIT);
	}

	//Init udp
	if (::GetPrivateProfileString(_T("UDP"), _T("ip"),   dafaultstr, pValue, 100, m_pathConfig)>0) SetDlgItemText(IDC_EDIT_IP, pValue);
	if (::GetPrivateProfileString(_T("UDP"), _T("port"), dafaultstr, pValue, 100, m_pathConfig)>0) SetDlgItemInt(IDC_EDIT_PORT, _ttoi(pValue));

	m_chRS422echo = FALSE;
	//RS422_GPS 
	m_rsGPS.Handle = NULL;
	m_rsGPS.nPos = 0;
	if (::GetPrivateProfileString(_T("GPS"), _T("comport"),  dafaultstr, pValue, 100, m_pathConfig)>0)	m_rsGPS.Comport.Format (_T("%s"), pValue);
	if (::GetPrivateProfileString(_T("GPS"), _T("baudrate"), dafaultstr, pValue, 100, m_pathConfig)>0)	m_rsGPS.Baudrate.Format(_T("%s"), pValue);
	//RS422_EMLog
	m_rsEMLog.Handle = NULL;
	m_rsEMLog.nPos = 0;
	if (::GetPrivateProfileString(_T("EMLOG"), _T("comport"),  dafaultstr, pValue, 100, m_pathConfig)>0)	m_rsEMLog.Comport.Format (_T("%s"), pValue);
	if (::GetPrivateProfileString(_T("EMLOG"), _T("baudrate"), dafaultstr, pValue, 100, m_pathConfig)>0)	m_rsEMLog.Baudrate.Format(_T("%s"), pValue);
	//RS422_GYRO
	m_rsGyro.Handle = NULL;
	m_rsGyro.nPos = 0;
	if (::GetPrivateProfileString(_T("GYRO"), _T("comport"),  dafaultstr, pValue, 100, m_pathConfig)>0)	m_rsGyro.Comport.Format(_T("%s"), pValue);
	if (::GetPrivateProfileString(_T("GYRO"), _T("baudrate"), dafaultstr, pValue, 100, m_pathConfig)>0)	m_rsGyro.Baudrate.Format(_T("%s"), pValue);
	//RS422_WIND
	m_rsWind.Handle = NULL;
	m_rsWind.nPos = 0;
	if (::GetPrivateProfileString(_T("WIND"), _T("comport"),  dafaultstr, pValue, 100, m_pathConfig)>0)	m_rsWind.Comport.Format(_T("%s"), pValue);
	if (::GetPrivateProfileString(_T("WIND"), _T("baudrate"), dafaultstr, pValue, 100, m_pathConfig)>0)	m_rsWind.Baudrate.Format(_T("%s"), pValue);

	if (m_rsGPS.Comport   != _T("")) DebugFunc(_T("GPS  : [%s] [%s]\r\n"), m_rsGPS.Comport,   m_rsGPS.Baudrate);
	if (m_rsEMLog.Comport != _T("")) DebugFunc(_T("EMLOG: [%s] [%s]\r\n"), m_rsEMLog.Comport, m_rsEMLog.Baudrate);
	if (m_rsGyro.Comport  != _T("")) DebugFunc(_T("GYRO : [%s] [%s]\r\n"), m_rsGyro.Comport,  m_rsGyro.Baudrate);
	if (m_rsWind.Comport  != _T("")) DebugFunc(_T("WIND : [%s] [%s]\r\n"), m_rsWind.Comport,  m_rsWind.Baudrate);
	/*
	BOOL bRet;
	bRet = ::WritePrivateProfileString(_T("GPS"),   _T("comport"),  _T("COM11"),  m_pathConfig);
	bRet = ::WritePrivateProfileString(_T("GPS"),   _T("baudrate"), _T("115200"), m_pathConfig);
	*/

	return TRUE;  // ��Ŀ���� ��Ʈ�ѿ� �������� ������ TRUE�� ��ȯ�մϴ�.
}

void CNetworkDlg::OnDestroy()
{
	CDialogEx::OnDestroy();

	// TODO: ���⿡ �޽��� ó���� �ڵ带 �߰��մϴ�.
	if (m_rsGPS.Handle   !=NULL) m_rsGPS.Handle->Close();
	if (m_rsEMLog.Handle !=NULL) m_rsEMLog.Handle->Close();
	if (m_rsGyro.Handle != NULL) m_rsGyro.Handle->Close();
	if (m_rsWind.Handle != NULL) m_rsWind.Handle->Close();
}

void CNetworkDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// ��ȭ ���ڿ� �ּ�ȭ ���߸� �߰��� ��� �������� �׸�����
//  �Ʒ� �ڵ尡 �ʿ��մϴ�.  ����/�� ���� ����ϴ� MFC ���� ���α׷��� ��쿡��
//  �����ӿ�ũ���� �� �۾��� �ڵ����� �����մϴ�.

void CNetworkDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // �׸��⸦ ���� ����̽� ���ؽ�Ʈ�Դϴ�.

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Ŭ���̾�Ʈ �簢������ �������� ����� ����ϴ�.
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// �������� �׸��ϴ�.
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// ����ڰ� �ּ�ȭ�� â�� ���� ���ȿ� Ŀ���� ǥ�õǵ��� �ý��ۿ���
//  �� �Լ��� ȣ���մϴ�.
HCURSOR CNetworkDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

//Debug memssage
void CNetworkDlg::DebugFunc(TCHAR *pszErr, ...)
{
	static CString strErr;
	va_list ap;
	va_start(ap, pszErr);
	strErr.FormatV(pszErr, ap);
	va_end(ap);

#if 0
	OutputDebugString(_T("(JSJ) : ") + strErr);
	//OutputDebugString(_T("\n"));
#else
	int len = m_ctrlEditLog.GetWindowTextLength();	// ���� ���̸� �޾ƿ���
	m_ctrlEditLog.SetSel(len, len);									// ���� ���̸�ŭ Ŀ�� �̵�
	m_ctrlEditLog.ReplaceSel(strErr);								// ����Ʈ �ڽ��� ���� �߰�
#endif
}
//Debug current time
CString time_str()
{
	SYSTEMTIME tm;
	char buffer[256];
	GetLocalTime(&tm);
	ZeroMemory(buffer, 256);
	_snprintf(buffer, 254, "%04d-%02d-%02d %02d:%02d:%02d %03d", tm.wYear, tm.wMonth, tm.wDay, tm.wHour, tm.wMinute, tm.wSecond, tm.wMilliseconds);
	return CString(buffer);
}



//UDP Receive
UINT ThreadForUDP(LPVOID param)
{
	CNetworkDlg* pMain = (CNetworkDlg*)param;

	SOCKADDR_IN peeraddr;
	int addrlen;
	char buf[UDP_BUF_SIZE + 1];
	int len, retval;
	CString str, tmp;

	while (pMain->b_UdpThread)
	{

		addrlen = sizeof(peeraddr);
		retval = recvfrom(pMain->m_sock, buf, UDP_BUF_SIZE, 0, (SOCKADDR*)&peeraddr, &addrlen);
		if (retval > 0) {

			str.Format(_T("\r\n[%s_%d]"), time_str(), retval);
			//printf("RX:%d",return);
			for (int i = 0; i < retval; i++) {
				tmp.Format(_T("%02X "), buf[i]);
				str += tmp;
			}
			
			int len = pMain->m_ctrlEditLog.GetWindowTextLength();
			pMain->m_ctrlEditLog.SetSel(len, len);
			pMain->m_ctrlEditLog.ReplaceSel(str);

		}
		Sleep(1000);
	}

	return 0;
}

//UDP Init
void CNetworkDlg::OnBnClickedBtnUdp()
{
	// TODO: ���⿡ ��Ʈ�� �˸� ó���� �ڵ带 �߰��մϴ�.
	CString udp_ip;
	GetDlgItemText(IDC_EDIT_IP, udp_ip);
	int udp_port = GetDlgItemInt(IDC_EDIT_PORT);

	// ���� �ʱ�ȭ
	WSADATA wsa;
	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
	{
		//return -1;
	}
	// socket()
	m_sock = socket(AF_INET, SOCK_DGRAM, 0);
	if (m_sock == INVALID_SOCKET)
	{
		//err_quit("socket()");
	}
	// ���� �ּ� ����ü �ʱ�ȭ
	SOCKADDR_IN serveraddr;
	ZeroMemory(&serveraddr, sizeof(serveraddr));
	serveraddr.sin_family = AF_INET;
	serveraddr.sin_port = htons(udp_port);
	serveraddr.sin_addr.s_addr = inet_addr( CT2A((LPCTSTR)udp_ip) );

	// ������ ��ſ� ����� ����
	SOCKADDR_IN peeraddr;
	int addrlen;
	char buf[UDP_BUF_SIZE + 1];
	int len;

	int retval, i;
	len = 10;
	for (i = 0; i < len; i++) buf[i] = i + 0x10;
	//retval = sendto(m_sock, buf, strlen(buf), 0, (SOCKADDR*)&serveraddr, sizeof(serveraddr));
	retval = sendto(m_sock, buf, len, 0, (SOCKADDR*)&serveraddr, sizeof(serveraddr));
	
	b_UdpThread = true;
	p_UdpThread = AfxBeginThread(ThreadForUDP, this);
	/*
	b_UdpThread = false;
	WaitForSingleObject(p_UdpThread->m_hThread, 5000);
	*/
}

//RS422 close
LRESULT CNetworkDlg::OnThreadClosed(WPARAM length, LPARAM lpara)
{
	((CMycomm*)lpara)->HandleClose();
	delete ((CMycomm*)lpara);

	return 0;
}


int g_aa_1[4][1000];

//RS422 receive
LRESULT CNetworkDlg::OnReceive(WPARAM length, LPARAM lpara)
{
	CString str=_T("");
	char data[20000];
	
	//RS422_GPS	
	if (m_rsGPS.Handle->m_nLength>0) {
		m_rsGPS.Handle->Receive(&m_rsGPS.Buf[m_rsGPS.nPos], length);
		m_rsGPS.nPos += length;		
		if (2 < m_rsGPS.nPos && m_rsGPS.Buf[m_rsGPS.nPos - 2] == '\r' && m_rsGPS.Buf[m_rsGPS.nPos - 1] == '\n') {
			str = _T("[A]");
			for (int i = 0; i < m_rsGPS.nPos; i++) str += m_rsGPS.Buf[i];
			m_rsGPS.nSize = m_rsGPS.nPos;
			m_rsGPS.nPos = 0;
			if (m_chRS422echo == TRUE) {
				memcpy(&m_rsGPS.Buf[m_rsGPS.nSize + 0], "[A]", 3);
				m_rsGPS.Handle->Send((LPCTSTR)m_rsGPS.Buf, m_rsGPS.nSize + 3);
			}
		}
		GetLocalTime(&m_rsGPS.timeRx);
	}
	//RS422_EMLog
	if (m_rsEMLog.Handle->m_nLength>0) {
		m_rsEMLog.Handle->Receive(&m_rsEMLog.Buf[m_rsEMLog.nPos], length);
		m_rsEMLog.nPos += length;
		if (2 < m_rsEMLog.nPos && m_rsEMLog.Buf[m_rsEMLog.nPos - 2] == '\r' && m_rsEMLog.Buf[m_rsEMLog.nPos - 1] == '\n') {
			str = str + _T("[B]");
			for (int i = 0; i < m_rsEMLog.nPos; i++) str += m_rsEMLog.Buf[i];
			m_rsEMLog.nSize = m_rsEMLog.nPos;
			m_rsEMLog.nPos = 0;
			if (m_chRS422echo == TRUE) {
				memcpy(&m_rsEMLog.Buf[m_rsEMLog.nSize + 0], "[B]", 3);
				m_rsEMLog.Handle->Send((LPCTSTR)m_rsEMLog.Buf, m_rsEMLog.nSize + 3);
			}
		}
		GetLocalTime(&m_rsEMLog.timeRx);
	}
	//RS422_Gyro
	if (m_rsGyro.Handle->m_nLength>0) {
		m_rsGyro.Handle->Receive(&m_rsGyro.Buf[m_rsGyro.nPos], length);
		m_rsGyro.nPos += length;
		if (2 < m_rsGyro.nPos && m_rsGyro.Buf[m_rsGyro.nPos - 2] == '\r' && m_rsGyro.Buf[m_rsGyro.nPos - 1] == '\n') {
			str = str + _T("[C]");
			for (int i = 0; i < m_rsGyro.nPos; i++) str += m_rsGyro.Buf[i];
			m_rsGyro.nSize = m_rsGyro.nPos;
			m_rsGyro.nPos = 0;
			if (m_chRS422echo == TRUE) {
				memcpy(&m_rsGyro.Buf[m_rsGyro.nSize + 0], "[C]", 3);
				m_rsGyro.Handle->Send((LPCTSTR)m_rsGyro.Buf, m_rsGyro.nSize + 3);
			}
		}
		GetLocalTime(&m_rsGyro.timeRx);
	}
	//RS422_Wind
	if (m_rsWind.Handle->m_nLength>0) {
		m_rsWind.Handle->Receive(&m_rsWind.Buf[m_rsWind.nPos], length);
		m_rsWind.nPos += length;
		if (2 < m_rsWind.nPos && m_rsWind.Buf[m_rsWind.nPos - 2] == '\r' && m_rsWind.Buf[m_rsWind.nPos - 1] == '\n') {
			str = str + _T("[D]");
			for (int i = 0; i < m_rsWind.nPos; i++) str += m_rsWind.Buf[i];
			m_rsWind.nSize = m_rsWind.nPos;
			m_rsWind.nPos = 0;
			if (m_chRS422echo == TRUE) {
				memcpy(&m_rsWind.Buf[m_rsWind.nSize + 0], "[D]", 3);
				m_rsWind.Handle->Send((LPCTSTR)m_rsWind.Buf, m_rsWind.nSize + 3);
			}
		}
		GetLocalTime(&m_rsWind.timeRx);
	}

	if (str != _T("")) {
		if (m_ctrlEditLog.GetWindowTextLengthW() > 10000) m_ctrlEditLog.SetWindowTextW(_T(""));
		m_ctrlEditLog.ReplaceSel(str);
	}

	return 0;
}

//RS422 init
void CNetworkDlg::OnBnClickedBtnRs232()
{

	CMycomm* Comm;
	CString tmp_port, tmp_rate;

	DebugFunc(_T(""));
	//RS422_GPS
	if (m_rsGPS.Comport != _T("")) {
		tmp_port = m_rsGPS.Comport;
		tmp_rate = m_rsGPS.Baudrate;
		Comm = (CMycomm*)m_rsGPS.Handle;
		if (Comm != NULL) {
			Comm->Close();
			Comm = NULL;
			DebugFunc(_T("GPS_'%s' closed!\r\n"), tmp_port);
		}
		else {
			Comm = new CMycomm(_T("\\\\.\\") + tmp_port, tmp_rate, _T("None"), _T("8 Bit"), _T("1 Bit")); // initial Comm port
			if (Comm->Create(GetSafeHwnd()) != 0) {
				DebugFunc(_T("opened! [%d]GPS_port:%s, baudrate:%s \r\n"), Comm->m_hComDev, Comm->m_sComPort, Comm->m_sBaudRate);
			}
			else {
				DebugFunc(_T("error! GPS_port:%s, baudrate:%s \r\n"), Comm->m_sComPort, Comm->m_sBaudRate);
			}
		}
		m_rsGPS.Handle = Comm;
	}

	//RS422_EMLog
	if (m_rsEMLog.Comport != _T("")) {
		tmp_port = m_rsEMLog.Comport;
		tmp_rate = m_rsEMLog.Baudrate;
		Comm = (CMycomm*)m_rsEMLog.Handle;
		if (Comm != NULL) {
			Comm->Close();
			Comm = NULL;
			DebugFunc(_T("EMLOG_'%s' closed!\r\n"), tmp_port);
		}
		else {
			Comm = new CMycomm(_T("\\\\.\\") + tmp_port, tmp_rate, _T("None"), _T("8 Bit"), _T("1 Bit")); // initial Comm port
			if (Comm->Create(GetSafeHwnd()) != 0) {
				DebugFunc(_T("opened! [%d]EMLOG_port:%s, baudrate:%s \r\n"), Comm->m_hComDev, Comm->m_sComPort, Comm->m_sBaudRate);
			}
			else {
				DebugFunc(_T("error! EMLOG_port:%s, baudrate:%s \r\n"), Comm->m_sComPort, Comm->m_sBaudRate);
			}
		}
		m_rsEMLog.Handle = Comm;
	}

	//RS422_Gyro
	if (m_rsGyro.Comport != _T("")) {
		tmp_port = m_rsGyro.Comport;
		tmp_rate = m_rsGyro.Baudrate;
		Comm = (CMycomm*)m_rsGyro.Handle;
		if (Comm != NULL) {
			Comm->Close();
			Comm = NULL;
			DebugFunc(_T("GYRO_'%s' closed!\r\n"), tmp_port);
		}
		else {
			Comm = new CMycomm(_T("\\\\.\\") + tmp_port, tmp_rate, _T("None"), _T("8 Bit"), _T("1 Bit")); // initial Comm port
			if (Comm->Create(GetSafeHwnd()) != 0) {
				DebugFunc(_T("opened! [%d]GYRO_port:%s, baudrate:%s \r\n"), Comm->m_hComDev, Comm->m_sComPort, Comm->m_sBaudRate);
			}
			else {
				DebugFunc(_T("error! GYRO_port:%s, baudrate:%s \r\n"), Comm->m_sComPort, Comm->m_sBaudRate);
			}
		}
		m_rsGyro.Handle = Comm;
	}

	//RS422_Wind
	if (m_rsWind.Comport != _T("")) {
		tmp_port = m_rsWind.Comport;
		tmp_rate = m_rsWind.Baudrate;
		Comm = (CMycomm*)m_rsWind.Handle;
		if (Comm != NULL) {
			Comm->Close();
			Comm = NULL;
			DebugFunc(_T("WIND_'%s' closed!\r\n"), tmp_port);
		}
		else {
			Comm = new CMycomm(_T("\\\\.\\") + tmp_port, tmp_rate, _T("None"), _T("8 Bit"), _T("1 Bit")); // initial Comm port
			if (Comm->Create(GetSafeHwnd()) != 0) {
				DebugFunc(_T("opened! [%d]WIND_port:%s, baudrate:%s \r\n"), Comm->m_hComDev, Comm->m_sComPort, Comm->m_sBaudRate);
			}
			else {
				DebugFunc(_T("error! WIND_port:%s, baudrate:%s \r\n"), Comm->m_sComPort, Comm->m_sBaudRate);
			}
		}
		m_rsWind.Handle = Comm;
	}
}




void CNetworkDlg::OnBnClickedBtnDump()
{
	SYSTEMTIME tm;
	CString str;
	const char *gpsQualityStr[] = {
		"0-Invalid",
		"1-Valid SPS",
		"2-Valid DGPS",
		"3-Valid PPS",
		"" };
	
	if (m_rsGPS.nSize > 0) {
		DebugFunc(_T("\r\n################################################################################\####\r\n"));
		tm = m_rsGPS.timeRx;
		str.Format(_T("GPS_RX_Time: %04d-%02d-%02d %02d:%02d:%02d %03d \r\nGPS_RX_Size: %d \r\nGPS_RX_Data: "), 
			tm.wYear, tm.wMonth, tm.wDay, tm.wHour, tm.wMinute, tm.wSecond, tm.wMilliseconds, 
			m_rsGPS.nSize);
		for (int i = 0; i < m_rsGPS.nSize; i++) str += m_rsGPS.Buf[i];
		DebugFunc(_T("%s *\r\n"), str);
		//parsing
		m_NMEAParser.ParseBuffer(m_rsGPS.Buf, m_rsGPS.nSize);
		DebugFunc(_T("UTC                           => %.3f \r\n"), m_NMEAParser._GGAHour*60.*60. + m_NMEAParser._GGAMinute*60. + m_NMEAParser._GGASecond);
		DebugFunc(_T("Latitude, Longitude, Altitude => %.6f deg, %.6f deg, %.3f m \r\n"), m_NMEAParser._GGALatitude, m_NMEAParser._GGALongitude, m_NMEAParser._GGAAltitude);
		if (0 <= m_NMEAParser._GGAGPSQuality && m_NMEAParser._GGAGPSQuality <= 3) {
			DebugFunc(_T("GPS Quality, #Satellite, HDOP => %s, %d, %.1f \r\n"), (CString)gpsQualityStr[m_NMEAParser._GGAGPSQuality], (int)m_NMEAParser._GGANumOfSatsInUse, m_NMEAParser._GGAHDOP);
		}
		DebugFunc(_T("Heading, Speed                => %6.0f deg, %6.3f Km/h \r\n"), m_NMEAParser._TrueCourse, m_NMEAParser._Km);
	}
	
	if (m_rsEMLog.nSize > 0) {
		DebugFunc(_T("\r\n################################################################################\####\r\n"));
		tm = m_rsEMLog.timeRx;
		str.Format(_T("EMLOG_RX_Time: %04d-%02d-%02d %02d:%02d:%02d %03d \r\nGPS_RX_Size: %d \r\nGPS_RX_Data: "),
			tm.wYear, tm.wMonth, tm.wDay, tm.wHour, tm.wMinute, tm.wSecond, tm.wMilliseconds,
			m_rsEMLog.nSize);
		for (int i = 0; i < m_rsEMLog.nSize; i++) str += m_rsEMLog.Buf[i];
		DebugFunc(_T("%s *\r\n"), str);
		//parsing
		m_NMEAParser.ParseBuffer(m_rsEMLog.Buf, m_rsEMLog.nSize);
		DebugFunc(_T("UTC                           => %.3f \r\n"), m_NMEAParser._GGAHour*60.*60. + m_NMEAParser._GGAMinute*60. + m_NMEAParser._GGASecond);
		DebugFunc(_T("Latitude, Longitude, Altitude => %.6f deg, %.6f deg, %.3f m \r\n"), m_NMEAParser._GGALatitude, m_NMEAParser._GGALongitude, m_NMEAParser._GGAAltitude);
		if (0 <= m_NMEAParser._GGAGPSQuality && m_NMEAParser._GGAGPSQuality <= 3) {
			DebugFunc(_T("GPS Quality, #Satellite, HDOP => %s, %d, %.1f \r\n"), (CString)gpsQualityStr[m_NMEAParser._GGAGPSQuality], (int)m_NMEAParser._GGANumOfSatsInUse, m_NMEAParser._GGAHDOP);
		}
		DebugFunc(_T("Heading, Speed                => %6.0f deg, %6.3f Km/h \r\n"), m_NMEAParser._TrueCourse, m_NMEAParser._Km);
	}

	if (m_rsGyro.nSize > 0) {
		DebugFunc(_T("\r\n################################################################################\####\r\n"));
		tm = m_rsGyro.timeRx;
		str.Format(_T("GYRO_RX_Time: %04d-%02d-%02d %02d:%02d:%02d %03d \r\nGPS_RX_Size: %d \r\nGPS_RX_Data: "),
			tm.wYear, tm.wMonth, tm.wDay, tm.wHour, tm.wMinute, tm.wSecond, tm.wMilliseconds,
			m_rsGyro.nSize);
		for (int i = 0; i < m_rsGyro.nSize; i++) str += m_rsGyro.Buf[i];
		DebugFunc(_T("%s *\r\n"), str);
		//parsing
		m_NMEAParser.ParseBuffer(m_rsGyro.Buf, m_rsGyro.nSize);
		DebugFunc(_T("UTC                           => %.3f \r\n"), m_NMEAParser._GGAHour*60.*60. + m_NMEAParser._GGAMinute*60. + m_NMEAParser._GGASecond);
		DebugFunc(_T("Latitude, Longitude, Altitude => %.6f deg, %.6f deg, %.3f m \r\n"), m_NMEAParser._GGALatitude, m_NMEAParser._GGALongitude, m_NMEAParser._GGAAltitude);
		if (0 <= m_NMEAParser._GGAGPSQuality && m_NMEAParser._GGAGPSQuality <= 3) {
			DebugFunc(_T("GPS Quality, #Satellite, HDOP => %s, %d, %.1f \r\n"), (CString)gpsQualityStr[m_NMEAParser._GGAGPSQuality], (int)m_NMEAParser._GGANumOfSatsInUse, m_NMEAParser._GGAHDOP);
		}
		DebugFunc(_T("Heading, Speed                => %6.0f deg, %6.3f Km/h \r\n"), m_NMEAParser._TrueCourse, m_NMEAParser._Km);
	}

	if (m_rsWind.nSize > 0) {
		DebugFunc(_T("\r\n################################################################################\####\r\n"));
		tm = m_rsWind.timeRx;
		str.Format(_T("WIND_RX_Time: %04d-%02d-%02d %02d:%02d:%02d %03d \r\nGPS_RX_Size: %d \r\nGPS_RX_Data: "),
			tm.wYear, tm.wMonth, tm.wDay, tm.wHour, tm.wMinute, tm.wSecond, tm.wMilliseconds,
			m_rsWind.nSize);
		for (int i = 0; i < m_rsWind.nSize; i++) str += m_rsWind.Buf[i];
		DebugFunc(_T("%s *\r\n"), str);
		//parsing
		m_NMEAParser.ParseBuffer(m_rsWind.Buf, m_rsWind.nSize);
		DebugFunc(_T("UTC                           => %.3f \r\n"), m_NMEAParser._GGAHour*60.*60. + m_NMEAParser._GGAMinute*60. + m_NMEAParser._GGASecond);
		DebugFunc(_T("Latitude, Longitude, Altitude => %.6f deg, %.6f deg, %.3f m \r\n"), m_NMEAParser._GGALatitude, m_NMEAParser._GGALongitude, m_NMEAParser._GGAAltitude);
		if (0 <= m_NMEAParser._GGAGPSQuality && m_NMEAParser._GGAGPSQuality <= 3) {
			DebugFunc(_T("GPS Quality, #Satellite, HDOP => %s, %d, %.1f \r\n"), (CString)gpsQualityStr[m_NMEAParser._GGAGPSQuality], (int)m_NMEAParser._GGANumOfSatsInUse, m_NMEAParser._GGAHDOP);
		}
		DebugFunc(_T("Heading, Speed                => %6.0f deg, %6.3f Km/h \r\n"), m_NMEAParser._TrueCourse, m_NMEAParser._Km);
	}


}


void CNetworkDlg::OnBnClickedRs422Echo()
{
	// TODO: ���⿡ ��Ʈ�� �˸� ó���� �ڵ带 �߰��մϴ�. 
	m_chRS422echo = IsDlgButtonChecked(IDC_RS422_ECHO);
}