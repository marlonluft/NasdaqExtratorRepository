import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import NaoEncontradoView from './Views/NaoEncontradoView.js'
import TelaInicialView from './Views/TelaInicialView.js'

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path='/404' component={NaoEncontradoView} />
        <Route exact path='/' component={TelaInicialView} />
        <Route component={NaoEncontradoView} />
      </Switch>
    </BrowserRouter>
  );
}

export default App;