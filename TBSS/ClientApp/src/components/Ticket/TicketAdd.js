import React, { useState } from 'react';
import axios from 'axios';

function TicketAdd() {
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();

        axios.post('/api/ticket', { title, description })
            .then((response) => {
                console.log('Ticket created:', response.data);
            })
            .catch((error) => {
                console.error('Error creating ticket:', error);
            });
    };

    return (
        <div>
            <h2>Add Ticket</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Title:</label>
                    <input
                        type="text"
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Description:</label>
                    <textarea
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                        required
                    ></textarea>
                </div>
                <button type="submit">Add Ticket</button>
            </form>
        </div>
    );
}

export default TicketAdd;
