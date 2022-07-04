import React from 'react';
import { useDispatch } from 'react-redux';
import { Box, Button, Container, makeStyles, Typography } from '@material-ui/core';
import Page from 'src/app/components/Page';
import { useNavigate } from 'react-router-dom';
import { logOutAction } from '../../../features/authSlice';

const useStyles = makeStyles((theme) => ({
  root: {
    backgroundColor: theme.palette.background.dark,
    height: '100%',
    paddingBottom: theme.spacing(3),
    paddingTop: theme.spacing(3)
  },
  image: {
    marginTop: 50,
    display: 'inline-block',
    maxWidth: '100%',
    width: 560
  }
}));

const DraftPageView = () => {
  const classes = useStyles();
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const goToLogin = () => {
      dispatch(logOutAction());
      navigate('/login');
  }

  return (
    <Page
      className={classes.root}
      title="Trang lỗi"
    >
      <Box
        display="flex"
        flexDirection="column"
        height="100%"
        justifyContent="center"
      >
        <Container maxWidth="md">
          <Typography
            align="center"
            color="textPrimary"
            variant="h1"
          >
            Đang trong quá trình chờ xác nhận tài khoản từ Admin
          </Typography>
          <Typography
            align="center"
            color="textPrimary"
            variant="subtitle2"
          >
              Vui Lòng liên hệ Admin để biết thêm chi tiết
          </Typography>
          <Typography
            align="center"
            color="textPrimary"
            variant="subtitle2"
            style={{marginTop:'50px'}}
          >
            <Button
                size="large"
                color="primary"
                variant="contained"
                onClick={goToLogin}
                >
                Đăng nhập
            </Button>
          </Typography>
          <Box textAlign="center">
            <img
              alt="Under development"
              className={classes.image}
              src="/static/images/undraw_page_not_found_su7k.svg"
            />
          </Box>
        </Container>
      </Box>
    </Page>
  );
};

export default DraftPageView;
