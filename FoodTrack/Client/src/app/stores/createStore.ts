import { History } from 'history';
import { TodoModel } from 'app/models';
import { RouterStore } from './RouterStore';
import { STORE_DASHBOARD, STORE_ROUTER } from 'app/constants';
import { DashboardStore, ShopList, shopListStatus } from './dashboardStore';

export function createStores(history: History, defaultCategory?: TodoModel[]) {
  let testData = [new ShopList('breakFirst', shopListStatus.ordered),new ShopList('bbq', shopListStatus.notOrdered)]
  // call api here to get shoplists
  const dashboardStore = new DashboardStore(testData);
  const routerStore = new RouterStore(history);
  return {
    [STORE_DASHBOARD]: dashboardStore,
    [STORE_ROUTER]: routerStore
  };
}
