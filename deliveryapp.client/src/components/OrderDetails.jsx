import {formatDate} from '../details/utils'

const OrderDetails = ({ order, onBack }) => {
  if (!order) return null;

  return (
    <div className="order-details">
      <h2>Детали заказа {order.orderNumber}</h2>
      
      <div className="details-section">
        <h3>Отправитель</h3>
        <p><strong>Город:</strong> {order.senderCity}</p>
        <p><strong>Адрес:</strong> {order.senderAddress}</p>
      </div>
      
      <div className="details-section">
        <h3>Получатель</h3>
        <p><strong>Город:</strong> {order.receiverCity}</p>
        <p><strong>Адрес:</strong> {order.receiverAddress}</p>
      </div>
      
      <div className="details-section">
        <h3>Груз</h3>
        <p><strong>Вес:</strong> {order.cargoWeight} кг</p>
        <p><strong>Дата забора:</strong> {formatDate(order.cargoPickupDate)}</p>
      </div>
      
      <button onClick={onBack}>Вернуться к списку</button>
    </div>
  );
};

export default OrderDetails;