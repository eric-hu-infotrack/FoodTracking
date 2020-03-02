import * as React from 'react';
import { Card, Button } from 'antd';
import { ShopList } from '../app/stores/dashboardStore';

export interface IItemDetails {
    shoppingCategory : string
    itemList: IItemList
}

export default class ItemDetails extends React.Component<IItemDetails> {
    public render() {
        return (
            <Row>
                <Col span={12}>col-12</Col>
                <Col span={12}>col-12</Col>
            </Row>
        );
    }
}
