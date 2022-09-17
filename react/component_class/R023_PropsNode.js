import React, {Component} from 'react';
import datatype from 'prop-types';
class R023_PropsNode extends Component {
  render() {
    return (
    <div style={{padding: "0px"}}>
      {this.props.children}
    </div>
    )
  }
}

export default R023_PropsNode;
