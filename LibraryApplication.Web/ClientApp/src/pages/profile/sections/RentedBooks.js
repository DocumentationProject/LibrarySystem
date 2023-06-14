import React, {useEffect, useState} from 'react';
import {Button, notification, Table, Tag} from "antd";
import {ArrowRightOutlined, CheckCircleOutlined, CloseCircleOutlined} from "@ant-design/icons";
import {useUser} from "../../../hooks/useUser";
import {API} from "../../../configs/axios.config";
import Title from "antd/es/typography/Title";

const RentedBooks = () => {
    const { user } = useUser();

    const [books, setBooks] = useState([])
    const [loading, setLoading] = useState(false)
    const [authors, setAuthors] = useState([])
    const [genres, setGenres] = useState([])

    useEffect(() => {
        (async () => {
            setLoading(true)
            try {
                const {data: newBooks} = await API.get(`/api/User/${user.id}/books`)
                setBooks(newBooks)
            } catch (e) {
                console.log(e)
            }
            setLoading(false)
        })()
    }, [])

    useEffect(() => {
        (async () => {
            try {
                const {data: newGenres} = await API.get(`/api/Genre/all`)
                setGenres(newGenres)
            } catch (e) {
                console.log(e)
            }
        })()
    }, [])

    useEffect(() => {
        (async () => {
            try {
                const {data: newAuthors} = await API.get(`/api/Author/all`)
                setAuthors(newAuthors)
            } catch (e) {
                console.log(e)
            }
        })()
    }, [])

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
            title: 'Genre',
            dataIndex: 'genre',
            key: 'genre',
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

    const data = books.map(book => {
        const author = authors.find(author => author.id === book.authorId)
        const genre = genres.find(genre => genre.id === book.genreId)

        return {
        key: book.id,
        name: book.name,
        author: author?.name + ' ' + author?.surname,
        genre: genre,
        rentPrice: book.rentPrice,
        rentedOn: book.rentedOn,
        rentedDue: book.rentedDue,
        overdue: book.overdue,
    }})

    return (
        <>
            <Title level={2}>Rented books</Title>
            <Table
                columns={columns}
                dataSource={data}
                pagination={false}
                loading={loading}
            />
        </>
    );
};

export default RentedBooks;