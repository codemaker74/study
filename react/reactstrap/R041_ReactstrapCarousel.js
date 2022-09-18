import React, { Component } from 'react';
import { UncontrolledCarousel } from 'reactstrap';
const items = [
  {
    src: 'https://cdn.pixabay.com/photo/2014/12/16/22/25/woman-570883_960_720.jpg',
    altText: '슬라이드1 이미지 대체 문구',
    caption: '슬라이드1 설명',
    header: '슬라이드1 제목'
  },
  {
    src: 'https://cdn.pixabay.com/photo/2021/11/24/11/01/autumn-6820879_960_720.jpg',
    altText: '슬라이드2 이미지 대체 문구',
    caption: '슬라이드2 설명',
    header: '슬라이드2 제목'
  },
  {
    src: 'https://cdn.pixabay.com/photo/2022/08/29/07/44/port-7418239_960_720.jpg',
    altText: '슬라이드3 이미지 대체 문구',
    caption: '슬라이드3 설명',
    header: '슬라이드3 제목'
  }
];

class R041_ReactstrapCarousel extends Component {
  render() {
    return (
        <UncontrolledCarousel items={items} />
    )}
}

export default R041_ReactstrapCarousel;