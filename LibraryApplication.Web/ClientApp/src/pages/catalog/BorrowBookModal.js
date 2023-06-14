import React from 'react';
import {Button, Form, InputNumber, Modal, notification} from "antd";
import {API} from "../../configs/axios.config";
import {useUser} from "../../hooks/useUser";

const BorrowBookModal = ({book, setShowModal}) => {
    const { user } = useUser();

    const onFinish = async (values) => {
        try {
             await API.post(`/api/Book/${book.id}/borrow`, {}, {
                params: {
                    userId: user.id,
                    rentInDays: values.rentInDays
                }})
            notification.success({message: 'Book borrowed!'})
            setShowModal(false)

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