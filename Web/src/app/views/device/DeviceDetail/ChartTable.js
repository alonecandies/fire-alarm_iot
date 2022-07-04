import React from 'react'
import PropTypes from 'prop-types'
import { Line } from 'react-chartjs-2'

const options = {
	plugins: {
		title: {
			display: true,
			text: 'Thống kê quan trắc môi trường Nhiệt độ - Độ ẩm',
			size: 20,
			padding: {
				top: 10,
				bottom: 30,
			},
		},
		legend: {
			display: true,
			position: 'top',
		},
	},
	scales: {
		yAxes: [
			{
				ticks: {
					beginAtZero: true,
				},
			},
		],
	},
}
ChartTable.propTypes = {
	data: PropTypes.array.isRequired,
}

function ChartTable({ data }) {
	const tmp = {
		// labels: ['1', '2', '3', '4', '5', '6'],
		labels: data.map(item => item.created_at),
		datasets: [
			{
				label: 'Nhiệt đô (℃)',
				data: data.map(item => item.temperature),
				fill: false,
				backgroundColor: 'rgb(255, 99, 132)',
				borderColor: 'rgba(255, 99, 132, 0.2)',
			},
			{
				label: 'Độ ẩm (g/m³)',
				data: data.map(item => item.humidity),
				fill: false,
				backgroundColor: 'rgba(128, 205, 231, 1)',
				borderColor: 'rgba(128, 205, 231, 0.5)',
			},
		],
	}
	return <Line data={tmp} options={options} />
}

export default ChartTable
