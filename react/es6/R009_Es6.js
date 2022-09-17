import React, {Component} from "react";

class R009_Es6 extends Component {
    constructor(props) {
        super(props);
        this.state = {};
    }

    componentDidMount() {
        var jsString1 = '자바스크립트';
        var jsString2 ='입니다\n다음 줄입니다.';
        console.log(jsString1 + ' 문자열' + jsString2 + '~');

        var Es6String1 = '';
        var Es6String2 = '';
        console.log(`${Es6String1} 문자열 ${Es6String2}!!!
------다음줄
  백틱을 사용하면 화면에 그데로 출력`);
        var LongString = "ES6에 추가된 String 함수들입니다.";
        console.log('startsWith >>> ' + LongString.startsWith("ES6에 추가"));
        console.log('endsWith >>> ' + LongString.endsWith("함수들입니다."));
        console.log('includes >>> ' + LongString.includes("추가된 String"));
    }

    render() {
        return (
            <h2>[THIS IS ES6 STRING]</h2>
        )
    }
}

export default R009_Es6;
