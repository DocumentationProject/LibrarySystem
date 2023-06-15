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
    
    const getBooks = async () => {
        const {data: newBooks} = await API.get(`/api/User/${user?.id}/books`)
        setBooks(newBooks)
    }

    useEffect(() => {
        (async () => {
            setLoading(true)
            try {
                await getBooks();
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
            title: 'Overdue',
            key: 'overdue',
            dataIndex: 'overdue',
            width: '96px',
            render: overdue => (
                <Tag icon={overdue ? <CloseCircleOutlined /> : <CheckCircleOutlined />} color={overdue ? 'error' : 'success'}>
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
                        await API.post(`/api/Book/${book.key}/return`, {}, {params: {userId: user?.id}})
                        notification.success({message: 'Book returned!'})
                        await getBooks();

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
        console.log(genre)

        return {
        key: book.id,
        name: book.name,
        author: author?.name + ' ' + author?.surname,
        genre: genre.name,
        rentPrice: book.rentPrice,
        overdue: book.overdue,
    }})

    return (
        <div className='mb-lg-4'>
            <Title level={2}>Rented books</Title>
            <Table
                columns={columns}
                dataSource={data}
                pagination={false}
                loading={loading}
            />
        </div>
    );
};

export default RentedBooks;