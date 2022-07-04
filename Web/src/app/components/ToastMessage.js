import React from 'react';
import Snackbar from '@material-ui/core/Snackbar';
import MuiAlert from '@material-ui/lab/Alert';
import { makeStyles } from '@material-ui/core/styles';
import { useDispatch, useSelector } from 'react-redux';
import { closeToast } from '../../features/uiSlice';
import PropTypes from 'prop-types'

ToastMessage.propsType={
  message:PropTypes.string.isRequired,
  type:PropTypes.oneOf(['success','error']),
  callBack:PropTypes.func.isRequired
}

function Alert(props) {
  return <MuiAlert elevation={6} variant="filled" {...props} />;
}

const useStyles = makeStyles(theme => ({
  root: {
    width: '100%',
    '& > * + *': {
      marginTop: theme.spacing(2)
    }
  }
}));

export default function ToastMessage({ message, type = 'success', callBack }) {
  const classes = useStyles();
  const dispatch = useDispatch();
  const show = useSelector(state => state.uiSlice.isShowToast);

  const handleClose = (event, reason) => {
    if (reason === 'clickaway') {
      return;
    }
    callBack&&callBack();
    dispatch(closeToast());
    // setIsShow(false);
  };

  return (
    <div className={classes.root}>
      <Snackbar open={show} autoHideDuration={2000} onClose={handleClose} anchorOrigin={{vertical:'top', horizontal:'right'}}>
        <Alert onClose={handleClose} severity={type}>
          {message}
        </Alert>
      </Snackbar>
    </div>
  );
}
