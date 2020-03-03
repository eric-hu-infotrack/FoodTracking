import * as React from 'react';
import { DashboardStore } from '../../stores/dashboardStore';
import ItemDetail from './itemDetails';
import { RouteComponentProps } from 'react-router';
import { inject } from 'mobx-react';
import { STORE_DASHBOARD } from 'app/constants';
import { Row, Col } from 'antd';

export interface IShopListContentProps extends RouteComponentProps {
}

@inject(STORE_DASHBOARD)
export default class ShopListContent extends React.Component<IShopListContentProps> {
    public render() {
        const dashboardStore = this.props[STORE_DASHBOARD] as DashboardStore;
        let id = parseInt(this.props.match.params['id']);
        const shopList = dashboardStore.shopLists.filter(x => x.id === id)[0]

        return (
            <Row className="shopListContent">
                <Col span={8}>
                {shopList.items.map(e => <ItemDetail item={e} />)}
                </Col>
            </Row>
        );
    }
}
