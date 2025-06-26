const API_URL = '/api/Delivery';

export const getOrders = async () => {
  const response = await fetch(`${API_URL}/GetOrders`);
  if (!response.ok) {
    throw new Error('Ошибка при загрузке заказов');
  }
  return await response.json();
};

export const getOrderById = async (id) => {
  const response = await fetch(`${API_URL}/GetOrder/${id}`);
  if (!response.ok) {
    throw new Error('Ошибка при загрузке деталей заказа');
  }
  return await response.json();
};

export const createOrder = async (orderData) => {
  const response = await fetch(`${API_URL}/CreateOrder`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(orderData),
  });
  if (!response.ok) {
    throw new Error('Ошибка при создании заказа');
  }
  return await response.json();
};