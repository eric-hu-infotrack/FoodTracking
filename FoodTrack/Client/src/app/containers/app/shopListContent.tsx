import * as React from 'react';
import { DashboardStore } from '../../stores/dashboardStore';
import ItemDetail from './itemDetails';
import { RouteComponentProps } from 'react-router';
import { inject } from 'mobx-react';
import { STORE_DASHBOARD } from 'app/constants';
import { Row, Col, Button } from 'antd';
import { DownloadOutlined, RollbackOutlined } from '@ant-design/icons/lib/icons';

export interface IShopListContentProps extends RouteComponentProps {
}

@inject(STORE_DASHBOARD)
export default class ShopListContent extends React.Component<IShopListContentProps> {
    public render() {
        const dashboardStore = this.props[STORE_DASHBOARD] as DashboardStore;
        let id = parseInt(this.props.match.params['id']);
        const shopList = dashboardStore.shopLists.filter(x => x.id === id)[0]

        return (
            <div className="shopListContent">
                <div className="back" onClick={() => this.goBack()}><RollbackOutlined /></div>
                <Row gutter={30}>
                    {shopList.items.map(e => <Col span={8}><ItemDetail item={e} /></Col>)}
                </Row>
                <Row className="exportButton" justify="center"> <Button size={'large'} icon={<DownloadOutlined />} >Save & Export</Button> </Row>
            </div>
        );
    }
    goBack() {
        this.props.history.push('/');
    }
}
