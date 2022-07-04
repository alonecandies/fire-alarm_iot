import React from 'react'
import PropTypes from 'prop-types'

CustomErrorMessage.propTypes = {
	content: PropTypes.string.isRequired,
}

function CustomErrorMessage({ content }) {
	return (
		<div
			style={{
				width: '100%',
				textAlign: 'center',
				fontWeight: 700,
				margin: 20,
				color: 'red',
				fontSize: 18,
			}}>
			{content}
		</div>
	)
}

export default CustomErrorMessage
