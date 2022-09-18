import React, { Component } from 'react';
import { Alert, UncontrolledAlert } from 'reactstrap';
class R034_ReactstrapAlerts extends Component {
  render() {
    return (
      <div>
      <Alert color="light">
        Simple Alert [color : light] - 기본 알림 영역
      </Alert>
      <UncontrolledAlert color="warning">
        Uncontrolled Alert [color : warning] - 삭제 기능이 추가된 알림 영역
      </UncontrolledAlert>
      </div>
    )
  }
}

export default R034_ReactstrapAlerts;