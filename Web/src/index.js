import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import * as serviceWorker from './serviceWorker';
import { Provider } from 'react-redux';
import store from './app/store';
import App from './App';
import ErrorBoundary from './app/layouts/ErrorBound';
import ToastProvider from "react-toaster-minimal";

ReactDOM.render((
  <Provider store={store}>
    <BrowserRouter>
      <ErrorBoundary>
      <ToastProvider>
        <App />
      </ToastProvider>
      </ErrorBoundary>
    </BrowserRouter>
  </Provider>
), document.getElementById('root'));

serviceWorker.unregister();
