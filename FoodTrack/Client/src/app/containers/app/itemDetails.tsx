import * as React from 'react';
import { Row, Card, Col, Input } from 'antd';
import { Item } from '../../stores/dashboardStore';
import { observer } from 'mobx-react';
import { PlusCircleOutlined, MinusCircleOutlined } from '@ant-design/icons';

export interface IItemDetail {
    item: Item
}

@observer
export default class ItemDetail extends React.Component<IItemDetail> {
    public render() {
        let toOrder = this.props.item.expectedNumber - this.props.item.inputNumber;
        let toOrderNumber = toOrder < 0 ? 0 : toOrder;
        return (
            <Card className="itemDetail">
                <Row>
                    <img
                        alt="example"
                        src={this.props.item.imageUrl}
                    />
                </Row>
                <Row>
                    <h1>{this.props.item.name}</h1>
                </Row>
                <Row>
                    
                    <Col span={8}><span className="icon" onClick={(e) => this.props.item.changeNumber(this.props.item.inputNumber + 1)}> <PlusCircleOutlined /></span></Col>
                    <Col span={8}><Input min={0} max={50} value= {this.props.item.inputNumber} defaultValue={this.props.item.inputNumber} onChange={(e) => this.props.item.changeNumber(+e.target.value)} /> </Col>
                    <Col span={8}><span className="icon" onClick={(e) => this.props.item.changeNumber(this.props.item.inputNumber - 1)}> <MinusCircleOutlined /> </span></Col>
                </Row>
                <Row>
                    <Col span={12}>
                        <Row><Col>Expected </Col></Row>
                        <Row><Col>{this.props.item.expectedNumber}</Col></Row>
                    </Col>
                    <Col span={12}>
                        <Row><Col>To Order</Col></Row>
                        <Row><Col> {toOrderNumber}</Col></Row>
                    </Col>
                </Row>
            </Card>
        );
    }

}
