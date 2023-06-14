import React from 'react';
import {useUser} from "../../hooks/useUser";
import {Button} from "antd";
import BooksList from "./BooksList";

const CatalogPage = () => {
    const { user } = useUser();

    return (<>
        <BooksList/>
    </>);
};

export default CatalogPage;