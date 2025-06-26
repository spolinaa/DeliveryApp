export const formatDate = (dateString) => {
    if (!dateString) return 'Нет даты';
    try {
        return new Date(dateString).toLocaleDateString('ru-RU');
    } catch {
        return dateString;
    }
};