import 'react-perfect-scrollbar/dist/css/styles.css';
import React from 'react';
import { useRoutes } from 'react-router-dom';
import { ThemeProvider } from '@material-ui/core';
import GlobalStyles from 'src/app/components/GlobalStyles';
import theme from 'src/app/theme';
import routes from 'src/routes';
import moment from 'moment';

import './App.css';
import 'moment/locale/vi';
require('dotenv');


const App = () => {
  moment.locale('vi');
  const routing = useRoutes(routes);

  return (
    <ThemeProvider theme={theme}>
      <GlobalStyles />
      {routing}
    </ThemeProvider>

  );
};

export default App;
