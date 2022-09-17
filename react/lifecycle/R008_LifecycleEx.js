import React, {Component} from "react";

class R008_LifecycleEx extends Component {

    //생명주기 함수중, 가장 먼저 실행(처음 한번만 호출), 내부변수(state)를 선언하고 부모객체에서 받은 변수(props)를 초기화,
    constructor(props) {
        super(props);
        this.state = {};
        console.log('1. constructor Call');
    }

    //새로운 props를 받게 되면 state를 변경,
    static getDerivedStateFromProps(props, state) {
        console.log('2. getDerivedStateFromProps Call >>> ' + props.prop_value);
        return {tmp_state:props.prop_value};
    }

    //return되는 html형식의 코드를 화면에 그려주는 함수(화면 내용이 변경될 시점에 자동호출)
    render() {
        console.log('3. render Call');
        return (
            <h2>[THIS IS CONSTRUCTOR FUCNTION]</h2>
        )
    }
    
    //가장 마지막에 실행, 이벤트/초기화등 가장 많이 사용,
    componentDidMount() {
        console.log('4. componentDidMount Call');
        console.log('4-1. tmp_state : ' + this.state.tmp_state);
        this.setState({tmp_state2 : true});
    }

    //prorp나 state가 변경될때 호출,
    shouldComponentUpdate(props, state) {
        console.log('5. shouldComponentUpdate Call / tmp_state2 >>> ' + state.tmp_state2);
        return state.tmp_state2;
    }
}

export default R008_LifecycleEx;