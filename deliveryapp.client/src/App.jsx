import React, { useState, useEffect } from 'react';
import { getOrders, getOrderById, createOrder } from './api/ordersApi';
import OrderList from './components/OrderList';
import CreateOrderForm from './components/CreateOrderForm';
import OrderDetails from './components/OrderDetails';
import './App.css';

const App = () => {
    const [orders, setOrders] = useState([]);
    const [selectedOrder, setSelectedOrder] = useState(null);
    const [showForm, setShowForm] = useState(false);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchOrders = async () => {
            try {
                const data = await getOrders();
                setOrders(data);
                setLoading(false);
            } catch (error) {
                console.error('Error fetching orders:', error);
                setLoading(false);
            }
        };

        fetchOrders();
    }, []);

    const handleOrderSelect = async (id) => {
        try {
            const order = await getOrderById(id);
            setSelectedOrder(order);
        } catch (error) {
            console.error('Error fetching order:', error);
        }
    };

    const handleOrderCreated = async (newOrder) => {
        try {
            const order = await createOrder(newOrder);
            setOrders([...orders, order]);
            setShowForm(false);
        } catch (error) {
            console.error('Error creating order:', error);
        }
    };

    if (loading) return (
    <div className="loading-container">
        <div className="modern-spinner">
            <div className="spinner-circle"></div>
            <div className="spinner-text">Загрузка заказов...</div>
        </div>
    </div>
    );

    if (selectedOrder) {
        return (
            <div className="app-container">
                <div className="content-container">
                    <OrderDetails 
                        order={selectedOrder} 
                        onBack={() => setSelectedOrder(null)} 
                    />
                </div>
            </div>
        );
    }

    if (showForm) {
        return (
            <div className="app-container">
                <div className="content-container">
                <CreateOrderForm 
                    onCreate={handleOrderCreated} 
                    onCancel={() => setShowForm(false)} 
                />
                </div>
            </div>
        );
    }

    return (
        <div className="app-container">
            <div className="content-container">
                <div className="page-header">
                    <h1>Заказы на доставку</h1>
                </div>
                <OrderList 
                    orders={orders} 
                    onOrderSelect={handleOrderSelect} 
                    onCreateNew={() => setShowForm(true)} 
                />
            </div>
        </div>
    );
};

export default App;