import * as React from 'react';
import { inject, observer } from 'mobx-react';
import { RouteComponentProps } from 'react-router';
import { DashboardStore } from '../../stores/dashboardStore';
import ShopListCard from './shopListCard';
import '../../common.less';
import {
  STORE_DASHBOARD,
  STORE_ROUTER,
  TodoFilter
} from 'app/constants';

export interface DashboardProps extends RouteComponentProps {
  /** MobX Stores will be injected via @inject() **/
  // [STORE_ROUTER]: RouterStore;
  // [STOURE_TODO]: TodoStore;
}

export interface TodoAppState {
  filter: TodoFilter;
}

@inject(STORE_DASHBOARD, STORE_ROUTER)
@observer
export class Dashboard extends React.Component<DashboardProps, TodoAppState> {
  constructor(props: DashboardProps, context: any) {
    super(props, context);
    this.state = { filter: TodoFilter.ALL };
  }

  componentWillMount() {
  }

  handleClick(index: number) {
    this.props.history.push('/shopList/' + index);
  }

  render() {
    const dashboardStore = this.props[STORE_DASHBOARD] as DashboardStore;

    return (
      <div className="dashboard">
        {dashboardStore.shopLists.map(e =>
          <div  key={e.name} onClick={() => this.handleClick(e.id)}>
            <ShopListCard shopList={e} />
          </div>
        )}
      </div>
    );
  }
}
