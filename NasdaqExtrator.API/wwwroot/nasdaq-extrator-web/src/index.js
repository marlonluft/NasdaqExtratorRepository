import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';

import reducer from './Reducers'

import { Provider } from 'react-redux'
import { createStore, applyMiddleware } from 'redux'
import thunk from "redux-thunk"

const store = createStore(reducer, applyMiddleware(thunk))

ReactDOM.render(
  <React.Fragment>
    <Provider store={store}>
      <App />
    </Provider>
  </React.Fragment>,
  document.getElementById('root')
);