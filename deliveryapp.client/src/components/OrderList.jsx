import {formatDate} from '../details/utils'

const OrderList = ({ orders, onOrderSelect, onCreateNew }) => {
    return (
        <div className="order-list">
            <div className="header">
                <button onClick={onCreateNew}>Добавить заказ</button>
            </div>
            <table>
                <thead>
                    <tr>
                        <th>Номер заказа</th>
                        <th>Город отправителя</th>
                        <th>Адрес отправителя</th>
                        <th>Город получателя</th>
                        <th>Адрес получателя</th>
                        <th>Вес груза (кг)</th>
                        <th>Дата забора груза</th>
                    </tr>
                </thead>
                <tbody>
                    {orders.map(order => (
                        <tr 
                            key={order.id} 
                            onClick={() => onOrderSelect(order.id)}
                            className="order-row"
                        >
                            <td>{order.id}</td>
                            <td>{order.senderCity}</td>
                            <td>{order.senderAddress}</td>
                            <td>{order.receiverCity}</td>
                            <td>{order.receiverAddress}</td>
                            <td>{order.cargoWeight}</td>
                            <td>{formatDate(order.cargoPickupDate)}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default OrderList;