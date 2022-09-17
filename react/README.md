
함! 리액트 해볼까나 ~ ~ ~


# React life cycle ?
https://serzhul.io/REACT/react-life-cycle(%EB%A6%AC%EC%95%A1%ED%8A%B8-%EC%83%9D%EB%AA%85-%EC%A3%BC%EA%B8%B0)

#생명주기 - 생성
"render" return되는 html형식의 코드를 화면에 그려주는 함수(화면 내용이 변경될 시점에 자동호출)
"constructor" 생명주기 함수중, 가장 먼저 실행(처음 한번만 호출), 내부변수(state)를 선언하고 부모객체에서 받은 변수(props)를 초기화,
"getDerivedStateFromProps" 새로운 props를 받게 되면 state를 변경,
"componentDidMount" 가장 마지막에 실행, 이벤트/초기화등 가장 많이 사용,

#생명주기 - 변경
"shouldComponentUpdate" prorp나 state가 변경될때 호출,
