import * as React from 'react';
import { Row, Card } from 'antd';
// import { PlusCircleOutlined, MinusCircleOutlined } from '@ant-design/icons';
import { Item } from '../../stores/dashboardStore';

export interface IItemDetail {
    item: Item
}

export default class ItemDetail extends React.Component<IItemDetail> {
    public render() {
        console.log('rendering');
        return (
            <Card>
                <Row>
                    <img
                        alt="example"
                        src={this.props.item.imageUrl}
                    />
                </Row>
                <Row>
                    <h1>{this.props.item.name}</h1>
                </Row>
                {/* <Row>
                    <Col> <PlusCircleOutlined /></Col>
                    <Col> {this.props.item.inputNumber}</Col>
                    <Col> <MinusCircleOutlined /></Col>
                </Row>
                <Row>
                    <Col> {this.props.item.expectedNumber}</Col>
                    <Col> {this.props.item.expectedNumber - this.props.item.inputNumber}</Col>
                </Row> */}
            </Card>
        );
    }
}
