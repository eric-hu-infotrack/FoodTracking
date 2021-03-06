import * as React from 'react';
import { hot } from 'react-hot-loader/root';
import { Router, Route, Switch } from 'react-router';
import { Root } from 'app/containers/Root';
import { Dashboard } from './containers/app';
import ShopListContent from './containers/app/shopListContent';

// render react DOM
export const App = hot(({ history }) => (
  <Root>
    <Router history={history}>
      <Switch>
        <Route exact path="/" component={Dashboard} />
        <Route path="/shopList/:id" component={ShopListContent} />
      </Switch>
    </Router>
  </Root>
));
