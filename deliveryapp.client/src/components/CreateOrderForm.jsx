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

  const [errors, setErrors] = useState({
    senderCity: '',
    senderAddress: '',
    receiverCity: '',
    receiverAddress: '',
    cargoWeight: '',
    pickupDate: '',
    senderAndReceiverLocations: ''
  });

  const validateField = (name, value) => {
    let error = '';
    
    switch (name) {
      case 'senderCity':
      case 'receiverCity':
        if (!value.trim()) error = 'Это поле обязательно';
        else if (value.length < 3) error = 'Минимум 3 символа';
        else if (value.length > 100) error = 'Максимум 100 символов';
        break;
      case 'senderAddress':
      case 'receiverAddress':
        if (!value.trim()) error = 'Это поле обязательно';
        else if (value.length < 5) error = 'Минимум 5 символов';
        else if (value.length > 200) error = 'Максимум 200 символов';
        break;
      
      case 'cargoWeight':
        if (!value) error = 'Введите вес';
        else if (isNaN(value) || parseFloat(value) <= 0) error = 'Введите число > 0';
        else if (parseFloat(value) > 1000) error = 'Максимум 1000 кг';
        break;
        
      default:
        break;
    }
    
    return error;
  };

  const validateSenderAndReceiverLocations = (formData) => {
    if (formData.senderCity == formData.receiverCity && formData.senderAddress == formData.receiverAddress)
      return 'Город и адрес отправителя и получателя должны быть разными';
    return '';
  }

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const handleBlur = (e) => {
    const { name, value } = e.target;
    setErrors(prev => ({
      ...prev,
      [name]: validateField(name, value)
    }));
  };


  const validateForm = () => {
    const newErrors = {
      senderCity: validateField('senderCity', formData.senderCity),
      senderAddress: validateField('senderAddress', formData.senderAddress),
      receiverCity: validateField('receiverCity', formData.receiverCity),
      receiverAddress: validateField('receiverAddress', formData.receiverAddress),
      cargoWeight: validateField('cargoWeight', formData.cargoWeight),
      pickupDate: validateField('pickupDate', formData.pickupDate),
      senderAndReceiverLocations: validateSenderAndReceiverLocations(formData)
    };
    
    setErrors(newErrors);
    return !Object.values(newErrors).some(error => error);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (validateForm()) {
      const orderData = {
        senderLocation: {
          city: formData.senderCity,
          address: formData.senderAddress
        },
        receiverLocation: {
          city: formData.receiverCity,
          address: formData.receiverAddress
        },
        cargo: {
          weight: parseFloat(formData.cargoWeight),
          pickupDate: new Date(formData.pickupDate)
        }
      };
      onCreate(orderData);
    }
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
            onBlur={handleBlur}
          />
          {errors.senderCity && <div className="error-message">{errors.senderCity}</div>}
        </div>
        
        <div className="form-group">
          <label>Адрес отправителя:</label>
          <input
            type="text"
            name="senderAddress"
            value={formData.senderAddress}
            onChange={handleInputChange}
            onBlur={handleBlur}
          />
          {errors.senderAddress && <div className="error-message">{errors.senderAddress}</div>}
        </div>
        
        <div className="form-group">
          <label>Город получателя:</label>
          <input
            type="text"
            name="receiverCity"
            value={formData.receiverCity}
            onChange={handleInputChange}
            onBlur={handleBlur}
          />
          {errors.receiverCity && <div className="error-message">{errors.receiverCity}</div>}
        </div>
        
        <div className="form-group">
          <label>Адрес получателя:</label>
          <input
            type="text"
            name="receiverAddress"
            value={formData.receiverAddress}
            onChange={handleInputChange}
            onBlur={handleBlur}
          />
          {errors.receiverAddress && <div className="error-message">{errors.receiverAddress}</div>}
        </div>
        
        <div className="form-group">
          <label>Вес груза (кг):</label>
          <input
            type="number"
            name="cargoWeight"
            value={formData.cargoWeight}
            onChange={handleInputChange}
            onBlur={handleBlur}
            min="0.1"
            max="1000"
            step="0.1"
          />
          {errors.cargoWeight && <div className="error-message">{errors.cargoWeight}</div>}
        </div>
        
        <div className="form-group">
          <label>Дата забора груза:</label>
          <input
            type="date"
            name="pickupDate"
            value={formData.pickupDate}
            onChange={handleInputChange}
            onBlur={handleBlur}
          />
          {errors.pickupDate && <div className="error-message">{errors.pickupDate}</div>}
        </div>
        {errors.senderAndReceiverLocations && <div className="error-message">{errors.senderAndReceiverLocations}</div>}
        <div className="form-actions">
          <button type="submit">Создать заказ</button>
          <button type="button" onClick={onCancel}>Отмена</button>
        </div>
      </form>
    </div>
  );
};


export default CreateOrderForm;