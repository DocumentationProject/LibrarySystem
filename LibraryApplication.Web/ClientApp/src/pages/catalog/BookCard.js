import React, {useState} from 'react';
import {Card} from "antd";
import {BookOutlined, DeleteOutlined, EditOutlined} from "@ant-design/icons";
import {useUser} from "../../hooks/useUser";
import BorrowBookModal from "./BorrowBookModal";

const BookCard = ({book}) => {
    const { user } = useUser();

    const [showBorrowBookModal, setShowBorrowBookModal] = useState(false)

    const cardActions = [<BookOutlined key="borrow" onClick={() => setShowBorrowBookModal(true)} />,]
    if (user.isAdmin) {
        cardActions.unshift(<DeleteOutlined key="delete" />)
        cardActions.unshift(<EditOutlined key="edit" />)
    }

    return (
        <Card
            actions={cardActions}
        >
            {showBorrowBookModal && <BorrowBookModal book={book} setShowModal={setShowBorrowBookModal}/>}
            <Card.Meta title={book.name}/>
        </Card>
    );
};

export default BookCard;