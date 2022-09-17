
함! 리액트 해볼까나 ~ ~ ~

# lifecycle 폴더
#React life cycle ?
https://serzhul.io/REACT/react-life-cycle(%EB%A6%AC%EC%95%A1%ED%8A%B8-%EC%83%9D%EB%AA%85-%EC%A3%BC%EA%B8%B0)

#생명주기 - 생성
"render" return되는 html형식의 코드를 화면에 그려주는 함수(화면 내용이 변경될 시점에 자동호출)
"constructor" 생명주기 함수중, 가장 먼저 실행(처음 한번만 호출), 내부변수(state)를 선언하고 부모객체에서 받은 변수(props)를 초기화,
"getDerivedStateFromProps" 새로운 props를 받게 되면 state를 변경,
"componentDidMount" 가장 마지막에 실행, 이벤트/초기화등 가장 많이 사용,

#생명주기 - 변경
"shouldComponentUpdate" prorp나 state가 변경될때 호출,

***
001 .jsx에 html 적용하기   
002 .jsx에 css 적용하기    
003 Component 사용하기
004 생명주기 함수 render() 사용하기
005 생명주기 함수 constructor(props) 사용하기
006 생명주기 함수 static getDerivedStateFormProps(props, state) 사용하기
007 생명주기 함수 componentDidMount() 사용하기
008 생명주기 함수 shouldComponentUpdate() 사용하기
009 템플릿 문자열 사용하기
010 var, let, const 사용하기
011 전개 연산자 사용하기
012 class 사용하기
013 화살표 함수 사용하기
014 forEach() 함수 사용하기
015 map() 함수 사용하기
016 jquery 사용하기

***
017 props 사용하기
018 props 자료형 선언하기
019 props Boolean으로 사용하기
020 props 객체형으로 사용하기
021 props를 필수 값으로 사용하기
022 props를 기본값으로 정의하기
023 props의 자식 Component에 node 전달하기
024 state 사용하기
025 setState() 함수 사용하기
026 state를 직접 변경한 후 forceUpdate() 함수 사용하기
027 Component 사용하기(class형 컴포넌트)
028 PureComponent 사용하기(class형 컴포넌트)
029 shallow-equal 사용하기(class형 컴포넌트)
030 함수형 컴포넌트 사용하기
031 hook 사용하기
032 Fragments 사용하기
033 map()으로 element 반환하기
034 reactstrap Alerts 사용하기
035 reactstrap Badge 사용하기
036 reactstrap Breadcrumbs 사용하기
037 reactstrap Button Dropdown 사용하기
038 reactstrap Button Group 사용하기
039 reactstrap Bottons 사용하기
040 reactstrap Card 사용하기
041 reactstrap Carousel 사용하기
042 reactstrap Collapse 사용하기
043 reactstrap Fade 사용하기
044 reactstrap Form 사용하기
045 reactstrap Input Group 사용하기
046 reactstrap Jumbotron 사용하기
047 reactstrap List Group 사용하기
048 reactstrap Modal 사용하기
049 reactstrap Navbar 사용하기
050 reactstrap Pagination 사용하기
051 reactstrap Popovers 사용하기
052 reactstrap Progress 사용하기
053 reactstrap Spinner 사용하기
054 reactstrap Table 사용하기
055 reactstrap Tab 사용하기
056 sweetalert2 Basic 사용하기
057 sweetalert2 position 사용하기
058 sweetalert2 confirm 사용하기
059 fetch get 호출하기
060 fetch post 호출하기
061 axios get 사용하기
062 axios post 사용하기
063 콜백 함수 사용하기
064 Promise then 사용하기
065 Promise catch 사용하기

***
066 click 이벤트 사용하기(onClick)
067 change 이벤트 사용하기(onChange)
068 mousemove 이벤트 사용하기(onMouseMove)
069 mouseover 이벤트 사용하기(onMouseOver)
070 mouseout 이벤트 사용하기(onMouseOut)
071 key 이벤트 사용하기(onKeyDown, onKeyPress, onKeyUp)
072 submit 이벤트 사용하기(onSubmit)
073 Ref 사용하기
074 커링 함수 구현하기
075 하이오더 컴포넌트 구현하기
076 컨텍스트 api 사용하기
077 컨텍스트로 부모 데이터 변경하기
078 redux 리듀서로 스토어 생성하기
079 redux 스토어 상속과 디스패치 함수 실행하기
080 redux 리듀서에서 스토어 데이터 변경하기
081 react-redux로 스토어 상속하기
082 react-redux로 스토어 데이터 사용하기
083 react-redux로 스토어 데이터 변경하기
084 redux 미들웨어 사용하기
085 react-cookies save 사용하기
086 react-cookies load 사용하기
087 react-cookies remove 사용하기
088 react-router-dom BrowserRouter 사용하기
089 react-router-dom Route 사용하기
090 react-router-dom Link 사용하기
091 header, footer 구현하기
092 home 페이지 만들기
093 〈react img〉 태그 사용하기
094 lodash 디바운스 사용하기
095 lodash 스로틀 사용하기

***
096 서울시 유동 인구 데이터 사용하기 ① - 리스트 페이지 만들기
097 서울시 유동 인구 데이터 사용하기 ② - Open api Key 발급받기
098 서울시 유동 인구 데이터 사용하기 ③ - JSON Viewer로 데이터 확인하기
099 서울시 유동 인구 데이터 사용하기 ④ - axios로 api 호출하기
100 recharts로 LineChart 구현하기 ①(서울시 유동 인구 데이터)
101 recharts로 LineChart 구현하기 ②(서울시 유동 인구 데이터)
102 recharts로 AreaChart 구현하기(서울시 유동 인구 데이터)
103 recharts로 BarChart 구현하기(서울시 유동 인구 데이터)
104 recharts로 ComposedChart 구현하기(서울시 유동 인구 데이터)
105 recharts로 ScatterChart 구현하기(서울시 유동 인구 데이터)

***
106 node.js express 프레임워크 설치하기
107 node 서버 구동하기
108 node 서버 api 호출하기
109 react 서버와 node 서버를 프록시로 연결하기
110 node 서버 api를 get로 json 데이터 호출하기
111 node 서버 api를 post로 json 데이터 호출하기
112 concurrently로 react, node 서버 한 번에 구동하기
113 MYSQL 서버 구축하기 ① - AWS 가입하기
114 MYSQL 서버 구축하기 ② - RDS 인스턴스 생성하기
115 MYSQL 서버 구축하기 ③ - RDS 인스턴스 포트 설정하기
116 MYSQL client 설치하기
117 workbench로 rds 서버 접속하기
118 MYSQL 스키마 생성 및 table 생성하기
119 MYSQL 한국 시간 설정하기
120 MYSQL 한글 설정 및 Safe 모드 해제하기
121 MYSQL 더미 데이터 삽입하기
122 NODE 조회 api 만들기 ① - body-parser 패키지 사용하기
123 NODE 조회 api 만들기 ② - mysql 서버 연결하기
124 NODE 조회 api 만들기 ③ - mybatis 패키지 사용하기
125 NODE 조회 api 만들기 ④ - api 호출로 데이터 확인하기
126 REACT 조회 페이지 만들기
127 DB 연결 풀 구현하기
128 NODE 등록 api 만들기 ① - insert 라우터 분기하기
129 NODE 등록 api 만들기 ② - insert 쿼리 추가, response 처리하기
130 REACT 등록 페이지 만들기
131 REACT 상세 조회 페이지 만들기
132 NODE 상세 조회 페이지 만들기- select 쿼리 where절 추가하기
133 NODE 수정 api 만들기 ① - update 라우터 분기하기
134 NODE 수정 api 만들기 ② - update 쿼리 추가, response 처리하기
135 REACT 수정 페이지 만들기
136 NODE 삭제 api 만들기 ① - delete 라우터 분기하기
137 NODE 삭제 api 만들기 ② - delete 쿼리 추가, response 처리하기
138 REACT 리스트 페이지 삭제 기능 구현하기
139 파일, 이미지 업로드 api 만들기 - multer 패키지 사용하기
140 REACT 등록 페이지 만들기 - 파일, 이미지 업로드 api 호출하기
141 REACT 등록 페이지 만들기 - 업로드 경로를 DB에 insert하기
142 REACT 상세 조회 페이지 만들기 - 파일, 이미지명 표시하기
143 REACT 수정 페이지 만들기 - 파일, 이미지 업로드 api 호출하기
144 REACT 수정 페이지 만들기 - 업로드 경로 DB에 업데이트하기
145 회원 정보 table 생성하기
146 NODE 회원 가입 api 만들기 ① - bcrypt로 암호화하기
147 NODE 회원 가입 api 만들기 ② - insert 쿼리 추가하기
148 REACT 회원 가입 페이지 만들기 ① - 입력 form 만들기
149 REACT 회원 가입 페이지 만들기 ② - 유효성 체크하기
150 REACT 회원 가입 페이지 만들기 ③ - 아이디 중복 체크하기
151 REACT 회원 가입 페이지 만들기 ④ - 회원 가입 api 호출하기
152 NODE 로그인 api 만들기 ① - 라우터 분기, 쿼리 추가하기
153 NODE 로그인 api 만들기 ② - bcrypt로 비밀번호 비교하기
154 REACT 로그인 페이지 만들기 - 로그인 api 호출하기
155 회원 정보 암호화 api 만들기 - jwt로 회원 정보 암호화하기
156 REACT 쿠키로 로그인 유지하기 - 쿠키에 회원 정보 저장하기
157 회원 정보 복호화 api 만들기 - jwt로 회원 정보 복호화하기
158 로그인 회원에게 권한 허용하기 - 쿠키에서 회원 정보 불러오기
159 로그인 세션 시간 관리하기 - 쿠키 유효 시간 연장하기
160 로그인 상태에서만 header 표시하기, 로그아웃 구현하기
161 비밀번호 재설정 메일 템플릿 만들기
162 메일 발송 api 만들기 - nodemailer 패키지 사용하기
163 비밀번호 조회 api 만들기 - 라우터 분기, 쿼리 추가하기
164 아이디와 회원명으로 비밀번호 조회 api 호출하기
165 비밀번호 재설정하기 - 이메일 발송 api 호출하기
166 GMAIL 계정 접근 권한 허용하기
167 수신된 이메일과 버튼 링크 확인하기
168 이메일 토큰으로 사용자 인증하기
169 비밀번호 수정 api 만들기 - 라우터 분기, 쿼리 추가하기
170 비밀번호 수정 api 호출하기
171 스케줄러 만들기 ① - 배치 테이블 생성하기
172 스케줄러 만들기 ② - node-cron 패키지 사용하기
173 스케줄러 만들기 ③ - 특정 시간에 insert 쿼리 실행하기
174 웹 서버 구축하기 ① - AWS EC2 인스턴스 생성하기
175 웹 서버 구축하기 ② - 포트 설정, 키 페어 다운로드하기
176 웹 서버 구축하기 ③ - 탄력적 IP 설정하기
177 MobaXterm - SFTP로 EC2 서버 접속하기
178 MobaXterm - SSH로 EC2 서버 접속하기
179 SFTP로 EC2 서버에 로컬 소스 옮기기
180 SSH로 EC2 서버에 소스 압축 풀기, nodejs 설치하기
181 react, node 서버에 필요한 패키지 설치하기
182 react, node 서버 구동해 외부에서 접속하기
183 EC2 서버 시간 한국으로 변경하기
184 vi 에디터로 EC2 서버 소스 직접 수정하기
185 chown, chmod 명령어로 서버 접근 권한 허용하기
186 nohup으로 서버 상시 구동하기, 포트로 서버 종료하기
187 kakao 지도 aPI appkey 발급하기, 웹 사이트 도메인 등록하기
188 react 서버 포트 80으로 설정하기
189 react에서 kakao 지도 생성하기
190 코로나 확진자 정보 excel 파일을 json 파일로 변환하기
191 확진자 위치에 마커 추가하기
192 확진자 위치에 이미지 마커 추가하기
193 마커에 클러스터러 사용하기
194 확진자 정보 커스텀 오버레이로 표시하기
195 EC2 서버에 로컬 react 소스 옮기기
196 EC2 서버에 react 패키지 설치하기
197 EC2 서버에 80포트 설정하기
198 카카오 웹 사이트 도메인에 EC2 IP 추가하기
199 screen으로 서버 상시 구동하기, 포트로 서버 종료하기
200 도메인 구매 후 ip 연결하기


