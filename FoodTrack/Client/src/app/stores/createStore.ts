import { History } from 'history';
import { RouterStore } from './RouterStore';
import { STORE_DASHBOARD, STORE_ROUTER } from 'app/constants';
import { DashboardStore } from './dashboardStore';

export function createStores(history: History) {
  let testData = [];
  // call api here to get shoplists
  const dashboardStore = new DashboardStore(testData);
  const routerStore = new RouterStore(history);
  return {
    [STORE_DASHBOARD]: dashboardStore,
    [STORE_ROUTER]: routerStore
  };
}