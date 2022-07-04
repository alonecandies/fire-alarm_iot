import React from 'react'
import { makeStyles } from '@material-ui/core/styles'
import Toolbar from '@material-ui/core/Toolbar'
import IconButton from '@material-ui/core/IconButton'
import Typography from '@material-ui/core/Typography'
import CloseIcon from '@material-ui/icons/Close'
import { ACTION_TABLE } from '../../../constant/config'

function ToolbarEdit({ closeToolbarRef, type }) {
	const classes = useStyles()

	const handleClose = isSave => {
		if (!closeToolbarRef) return
		closeToolbarRef(isSave)
	}

	return (
		<Toolbar>
			<IconButton
				edge='start'
				color='inherit'
				onClick={() => handleClose()}
				aria-label='close'>
				<CloseIcon />
			</IconButton>
			<Typography variant='h6' className={classes.title}>
				{type === ACTION_TABLE.CREATE
					? 'Tạo mới thiết bị'
					: 'Cập nhật thiết bị'}
			</Typography>
		</Toolbar>
	)
}

const useStyles = makeStyles(theme => ({
	appBar: {
		position: 'relative',
	},
	title: {
		marginLeft: theme.spacing(2),
		flex: 1,
	},
}))

export default ToolbarEdit
