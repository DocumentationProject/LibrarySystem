import React from 'react';
import RentedBooks from "./sections/RentedBooks";
import {useUser} from "../../hooks/useUser";
import PromoCodes from "./sections/PromoCodes";

const ProfilePage = () => {
    const { user } = useUser();

    return (
        <div>
            <RentedBooks/>
            {user?.isAdmin && <PromoCodes/>}
        </div>
    );
};

export default ProfilePage;