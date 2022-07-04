import React from 'react';
import PropTypes from 'prop-types';

TextHightLight.propTypes = {
    content:PropTypes.string.isRequired,
    type: PropTypes.oneOf(['blue' , 'red' ,'green'] ).isRequired
};

function TextHightLight({content='text' , type }) {
  let color = ''
  switch (type){
    case 'blue':
      color = "#3f51b5"
      break;
    case 'red':
      color = '#ff0040'
      break;
    case 'green':
      color = '#33CC00'
      break;
    default:
      color = '3f51b5'
  }
  return (
    <b style={{ color: color}}>{content}</b>
  );
}
export default TextHightLight

