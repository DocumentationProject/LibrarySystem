import React from 'react';
import {Button, Form, InputNumber, Modal, notification} from "antd";
import {API} from "../../configs/axios.config";
import {useUser} from "../../hooks/useUser";
import {useAuth} from "../../hooks/useAuth";

const BorrowBookModal = ({book, setShowModal, getBooks}) => {
    const { user } = useUser();
    const { login } = useAuth();
    const onFinish = async (values) => {
        try {
             const isSuccess = await API.post(`/api/Book/${book.id}/borrow`, {
                    userId: user.id,
                    rentInDays: values.rentInDays
                })
            const {data: newUser} = await API.get(`/api/User/${user.id}`)
            login(newUser)
            
            isSuccess.data === true 
                ? notification.success({message: 'Book borrowed!'}) 
                : notification.error({message: 'Failed to borrow book!'})
            
            setShowModal(false)

            await getBooks();
        } catch (e) {
            console.log(e)
        }
    }

    return (
        <Modal
            title="Add book"
            open={true}
            onCancel={() => setShowModal(false)}
            footer={null}
        >
            <Form
                name="borrow-book"
                initialValues={{
                    remember: true,
                }}
                onFinish={onFinish}
                requiredMark={false}
                layout="vertical"
            >
                <Form.Item
                    name="rentInDays"
                    label="Rent in days"
                    rules={[{required: true, message: 'Please, enter days number of rent'}]}
                    initialValue={0}

                >
                    <InputNumber/>
                </Form.Item>
                <Form.Item>
                    <Button type="primary" htmlType="submit">
                        Borrow
                    </Button>
                </Form.Item>
            </Form>
        </Modal>
    );
};

export default BorrowBookModal;