import React, { useState } from 'react';

const CreateOrderForm = ({ onCreate, onCancel }) => {
  const [formData, setFormData] = useState({
    senderCity: '',
    senderAddress: '',
    receiverCity: '',
    receiverAddress: '',
    cargoWeight: '',
    pickupDate: ''
  });

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const orderData = {
        senderLocation:{city:formData.senderCity,address:formData.senderAddress},
        receiverLocation:{city:formData.receiverCity,address:formData.receiverAddress},
        cargo:{weight:parseFloat(formData.cargoWeight),pickupDate:new Date(formData.pickupDate)}
    };
    onCreate(orderData);
  };

  return (
    <div className="form-container">
      <h2>Создать новый заказ</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>Город отправителя:</label>
          <input
            type="text"
            name="senderCity"
            value={formData.senderCity}
            onChange={handleInputChange}
            required
          />
        </div>
        
        <div className="form-group">
          <label>Адрес отправителя:</label>
          <input
            type="text"
            name="senderAddress"
            value={formData.senderAddress}
            onChange={handleInputChange}
            required
          />
        </div>
        
        <div className="form-group">
          <label>Город получателя:</label>
          <input
            type="text"
            name="receiverCity"
            value={formData.receiverCity}
            onChange={handleInputChange}
            required
          />
        </div>
        
        <div className="form-group">
          <label>Адрес получателя:</label>
          <input
            type="text"
            name="receiverAddress"
            value={formData.receiverAddress}
            onChange={handleInputChange}
            required
          />
        </div>
        
        <div className="form-group">
          <label>Вес груза (кг):</label>
          <input
            type="number"
            name="cargoWeight"
            value={formData.cargoWeight}
            onChange={handleInputChange}
            required
            min="0.1"
            max="1000"
            step="0.1"
          />
        </div>
        
        <div className="form-group">
          <label>Дата забора груза:</label>
          <input
            type="date"
            name="pickupDate"
            value={formData.pickupDate}
            onChange={handleInputChange}
            required
          />
        </div>
        
        <div className="form-actions">
          <button type="submit">Создать заказ</button>
          <button type="button" onClick={onCancel}>Отмена</button>
        </div>
      </form>
    </div>
  );
};

export default CreateOrderForm;