
// NetworkDlg.h : 헤더 파일
//

#pragma once
#include "afxwin.h"
#include "Mycomm.h"
#include "NMEAParser.h"


#define UDP_BUF_SIZE		512
#define SERIAL_BUF_MAX	20000
class CSerialData
{
public:
	CMycomm*		Handle;
	CString			Comport;
	CString			Baudrate;
	int					nPos;
	int					nSize;
	char				Buf[SERIAL_BUF_MAX];
	SYSTEMTIME	timeRx;
	SYSTEMTIME	timeTx;
};


// CNetworkDlg 대화 상자
class CNetworkDlg : public CDialogEx
{
// 생성입니다.
public:
	CNetworkDlg(CWnd* pParent = NULL);	// 표준 생성자입니다.
	
// 대화 상자 데이터입니다.
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_NETWORK_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 지원입니다.


// 구현입니다.
protected:
	HICON m_hIcon;

	// 생성된 메시지 맵 함수
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:

	void DebugFunc(TCHAR *pszErr, ...);
	CString m_pathConfig;

	CWinThread* p_UdpThread;
	bool b_UdpThread;
	CEdit m_ctrlEditLog;
	SOCKET m_sock;		
	
	BOOL m_chRS422echo;
	//RS422
	LRESULT	OnThreadClosed(WPARAM length, LPARAM lpara);
	LRESULT	OnReceive(WPARAM length, LPARAM lpara);
	CSerialData m_rsGPS;
	CSerialData m_rsEMLog;
	CSerialData m_rsGyro;
	CSerialData m_rsWind;
	//Parser
	CNMEAParser m_NMEAParser;

	afx_msg void OnDestroy();
	afx_msg void OnBnClickedBtnUdp();
	afx_msg void OnBnClickedBtnRs232();
	afx_msg void OnBnClickedBtnDump();
	afx_msg void OnBnClickedRs422Echo();
};
