import React, { useState, useEffect } from 'react';
import axios from 'axios';

function TicketList() {
    const [tickets, setTickets] = useState([]);

    useEffect(() => {
        axios.get('/api/ticket')
            .then((response) => {
                setTickets(response.data);
            })
            .catch((error) => {
                console.error('Error fetching tickets:', error);
            });
    }, []);

    return (
        <div>
            <h2>Ticket List</h2>
            <ul>
                {tickets.map((ticket) => (
                    <li key={ticket.id}>{ticket.title}</li>
                ))}
            </ul>
        </div>
    );
}

export default TicketList;
