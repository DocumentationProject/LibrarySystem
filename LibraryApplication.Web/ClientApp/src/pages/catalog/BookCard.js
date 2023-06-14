import React, {useState} from 'react';
import {Button, Card, notification, Statistic} from "antd";
import {BookOutlined, DeleteOutlined, EditOutlined} from "@ant-design/icons";
import {useUser} from "../../hooks/useUser";
import BorrowBookModal from "./BorrowBookModal";
import {API} from "../../configs/axios.config";
import Paragraph from "antd/es/typography/Paragraph";

const BookCard = ({book, setBooks}) => {
    const { user } = useUser();

    const [showBorrowBookModal, setShowBorrowBookModal] = useState(false)

    const handleDeleteBook = async () => {
        try {
            await API.delete(`/api/Book/${book.id}/delete`)
            notification.success({message: 'Book deleted!'})
            setBooks(prevBooks => prevBooks.filter(b => b.id !== book.id))
        } catch (e) {
            console.log(e)
        }
    }

    const cardActions = [<Button type='text' onClick={() => setShowBorrowBookModal(true)} icon={<BookOutlined key="borrow"  />} disabled={!book.isAvailable}/>]
    if (user.isAdmin) {
        cardActions.unshift(<Button type='text' onClick={handleDeleteBook} icon={<DeleteOutlined key="delete"  />}/>)
        cardActions.unshift(<Button type='text' icon={<EditOutlined key="edit" />}/>)
    }

    return (
        <Card
            title={book.name}
            actions={cardActions}
        >
            {showBorrowBookModal && <BorrowBookModal book={book} setShowModal={setShowBorrowBookModal}/>}
            <Paragraph>Author: {book.authorId}</Paragraph>
            <Paragraph>Genre: {book.genreId}</Paragraph>
            <Statistic
                title="Rent price"
                value={book.rentPrice}
                prefix="$"
            />
        </Card>
    );
};

export default BookCard;