import React from 'react';
import {Card} from "antd";
import {BookOutlined, DeleteOutlined, EditOutlined} from "@ant-design/icons";
import {useUser} from "../../hooks/useUser";

const BookCard = ({book}) => {
    const { user } = useUser();

    const cardActions = [<BookOutlined key="delete" />,]
    if (user.isAdmin) {
        cardActions.unshift(<DeleteOutlined key="delete" />)
        cardActions.unshift(<EditOutlined key="edit" />)
    }

    return (
        <Card
            actions={cardActions}
        >
            <Card.Meta title={book.name}/>
        </Card>
    );
};

export default BookCard;