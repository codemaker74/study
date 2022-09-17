import React, {Component} from "react";

class R006_LifecycleEx extends Component {

    constructor(props) {
        super(props);
        this.state = {};
        console.log('1. constructor Call');
    }
    
    static getDerivedStateFromProps(props, state) {
        console.log('2. getDerivedStateFromProps Call >>> ' + props.prop_value);
        return {};
    }

    render() {
        console.log('3. render Call');
        return (
            <h2>[THIS IS CONSTRUCTOR FUCNTION]</h2>
        )
    }
}

export default R006_LifecycleEx;