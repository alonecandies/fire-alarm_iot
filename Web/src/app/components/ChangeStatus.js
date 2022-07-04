import React, { useState } from 'react';
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  FormControl,
  FormControlLabel,
  makeStyles,
  Radio,
  RadioGroup,
  Slide
} from '@material-ui/core';

const Transition = React.forwardRef(function Transition(props, ref) {
  return <Slide direction='up' ref={ref} {...props} />;
});

export default function ChangeStatus({
                                       status,
                                       open,
                                       closeChangeStatusRef,
                                       saveStatusRef,
                                       title,
                                       listStatus
                                     }) {
  const classes = useStyles();
  const [statusSelected, setStatusSelected] = useState(status);

  const handleClose = () => {
    closeChangeStatusRef(false);
  };

  const handleSaveChange = event => {
    const satusSelect = event.target.value;
    setStatusSelected(satusSelect);
  };
  const save = () => {
    if (!saveStatusRef) return;
    saveStatusRef(statusSelected);
  };

  return (
    <div>
      <Dialog
        open={open}
        TransitionComponent={Transition}
        keepMounted
        onClose={handleClose}
        aria-labelledby='alert-dialog-slide-title'
        aria-describedby='alert-dialog-slide-description'
      >
        <DialogTitle id='alert-dialog-slide-title'>
          <span className={classes.styleTitle}>
            {title || 'Thay đổi trạng thái '}
          </span>
        </DialogTitle>
        <DialogContent>
          <FormControl component='fieldset'>
            <RadioGroup
              onChange={(e) => handleSaveChange(e)}
              aria-label='status'
              name='status'
              value={statusSelected ? statusSelected.toString() : ''}
            >
              {listStatus.map(status => (
                <FormControlLabel
                  key={status.id}
                  value={status.id.toString()}
                  control={<Radio />}
                  label={status.value || status.title}
                />
              ))}
            </RadioGroup>
          </FormControl>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} color='primary'>
            Hủy
          </Button>
          <Button onClick={save} color='primary'>
            Xác nhận
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}

const useStyles = makeStyles(theme => ({
  styleTitle: {
    fontSize: '24px',
    color: '#3f51b5'
  }
}));
