import React, { useEffect, useState } from 'react'
import PropTypes from 'prop-types'
import { Search as SearchIcon } from 'react-feather'
import CircularProgress from '@material-ui/core/CircularProgress'
import clsx from 'clsx'
import {
	Box,
	Button,
	Card,
	CardContent,
	InputAdornment,
	makeStyles,
	SvgIcon,
	TextField,
} from '@material-ui/core'
import { green } from '@material-ui/core/colors'
import Typography from '@material-ui/core/Typography'
import { Autocomplete } from '@material-ui/lab'
import { useDispatch, useSelector } from 'react-redux'
import { GetAllLocation } from '../../../features/locationSlice'
import { STATUS_API } from '../../constant/config'

const Toolbar = ({
	className,
	searchRef,
	isLoading,
	onCreateDevice,
	data,
	...rest
}) => {
	const classes = useStyles()

	const dispatch = useDispatch()
	// const statusGetAll = useSelector(state => state.locationSlice.statusGetAll)
	// const listLocation = useSelector(state => state.locationSlice.listLocation)
	let listLocation = data
	const [value, setValue] = React.useState(listLocation?.map(item => item.id))
	const [inputValue, setInputValue] = React.useState('')
	const options = listLocation
		? listLocation.map(item => item.location_name)
		: []
	// useEffect(() => {
	// 	dispatch(GetAllLocation())
	// }, [dispatch])

	const clearSearch = () => {
		if (!inputValue) return
		setValue('')
		setInputValue('')
		searchRef(null)
	}
	const searchDevice = () => {
		if (!searchRef) return
		let tmpId = listLocation.filter(item => item.location_name === value)[0]
			.id
		searchRef(tmpId)
	}

	return (
		<div className={clsx(classes.root, className)} {...rest}>
			<Box>
				<Card>
					<CardContent>
						<Box className={classes.groupSearch}>
							<div className={classes.groupSearch}>
								<Autocomplete
									value={value}
									onChange={(event, newValue) => {
										setValue(newValue)
									}}
									inputValue={inputValue}
									onInputChange={(event, newInputValue) => {
										setInputValue(newInputValue)
									}}
									loading={isLoading}
									id='controllable-states'
									options={options}
									style={{ width: 300 }}
									renderInput={params => (
										<TextField
											{...params}
											label='Địa điểm'
											variant='outlined'
										/>
									)}
								/>
								<div className={classes.wrapper}>
									<Button
										className={classes.styleInputSearch}
										color='primary'
										variant='contained'
										onClick={() => searchDevice()}>
										{isLoading ? (
											<span>Tìm kiếm </span>
										) : (
											'loading'
										)}
									</Button>
									{isLoading && (
										<CircularProgress
											size={24}
											className={classes.buttonProgress}
										/>
									)}
								</div>
								<Button
									className={classes.styleInputSearch}
									color='inherit'
									variant='contained'
									onClick={clearSearch}>
									Bỏ Lọc
								</Button>
							</div>
							<Button
								onClick={() => onCreateDevice()}
								size={'large'}
								variant={'contained'}
								color={'secondary'}>
								Tạo mới
							</Button>
						</Box>
					</CardContent>
				</Card>
			</Box>
		</div>
	)
}

Toolbar.propTypes = {
	className: PropTypes.string,
}

const useStyles = makeStyles(theme => ({
	root: {},
	importButton: {
		marginRight: theme.spacing(1),
	},
	wrapper: {
		margin: theme.spacing(1),
		position: 'relative',
	},
	formControl: {
		margin: theme.spacing(1),
		minWidth: 120,
	},
	buttonProgress: {
		color: green[500],
		position: 'absolute',
		top: '50%',
		left: '50%',
		marginTop: -12,
		marginLeft: -12,
	},
	exportButton: {
		marginRight: theme.spacing(1),
	},
	groupSearch: {
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'space-between',
	},
	searchInput: {
		width: '400px',
	},
	styleInputSearch: {
		height: '55px',
	},
}))

export default Toolbar
