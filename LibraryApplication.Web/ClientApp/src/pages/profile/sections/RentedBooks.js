import React from 'react';
import {Button, notification, Table, Tag} from "antd";
import {ArrowRightOutlined, CheckCircleOutlined, CloseCircleOutlined} from "@ant-design/icons";
import {useUser} from "../../../hooks/useUser";
import {API} from "../../../configs/axios.config";

const RentedBooks = () => {
    const { user } = useUser();

    const columns = [
        {
            title: 'Name',
            dataIndex: 'name',
            key: 'name',
        },
        {
            title: 'Author',
            dataIndex: 'author',
            key: 'author',
        },
        {
            title: 'Rent price',
            dataIndex: 'rentPrice',
            key: 'rentPrice',
        },
        {
            title: 'Rented on',
            dataIndex: 'rentedOn',
            key: 'rentedOn',
        },
        {
            title: 'Rented due',
            dataIndex: 'rentedDue',
            key: 'rentedDue',
        },
        {
            title: 'Overdue',
            key: 'overdue',
            dataIndex: 'overdue',
            width: '96px',
            render: overdue => (
                <Tag icon={overdue ? <CloseCircleOutlined /> : <CheckCircleOutlined />} color={overdue ? 'success' : 'error'}>
                    {overdue ? 'OVERDUE' : 'ON TIME'}
                </Tag>
            )

        },
        {
            title: 'Action',
            key: 'action',
            width: '8%',
            render: book => {
                const handleReturnBook = async () => {
                    try {
                        await API.post(`/api/Book/${book.id}/return`, {
                            userId: user.id
                        })
                        notification.success({message: 'Book returned!'})

                    } catch (error) {
                        console.log(error)
                    }
                }

                return <Button
                            shape='circle'
                            type='text'
                            onClick={handleReturnBook}
                        >
                            <ArrowRightOutlined/>
                        </Button>
            }
        }
    ];

    // const data = criteria.map((criterion, index) => ({
    //     key: index,
    //     criterion: criterion.criterion,
    //     reasoning: criterion.reasoning,
    //     met: criterion.is_met,
    // }))

    return (
        <Table
            columns={columns}
            //dataSource={data}
            pagination={false}
            //loading={loading}
        />
    );
};

export default RentedBooks;