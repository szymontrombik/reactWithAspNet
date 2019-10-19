import React, { Component } from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';
import { USERS_API_URL } from '../../constants';

class RegistrationForm extends Component {
    state = {
        id: 0,
        name: '',
        document: '',
        email: '',
        phone: ''
    }

    componentDidMount() {
        if (this.props.user) {
            const { id, name, document, email, phone } = this.props.user
            this.setState({ id, name, document, email, phone });
        }
    }

    onChange = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    submitNew = e => {
        e.preventDefault();
        fetch(`${USERS_API_URL}`, {
            method: 'post',
            headers: {
                'Content-Type' : 'application/json'
            },
            body: JSON.stringify({
                name: this.state.name,
                email : this.state.email,
                document: this.state.document,
                phone: this.state.phone
            })
        })
            .then(res => res.json())
            .then(user => {
                this.props.addUserToState(user);
                this.props.toggle();
            })
            .catch(err => console.log(err));
    }

    submitEdit = e => {
        e.preventDefault();
        fetch(`${USERS_API_URL}`, {
            method: 'put',
            headers: {
                'Content-Type' : 'application/json'
            },
            body: JSON.stringify({
                name: this.state.name,
                email : this.state.email,
                document: this.state.document,
                phone: this.state.phone
            })
        })
            .then(res => res.json())
            .then(user => {
                this.props.toggle();
                this.props.updateUserIntoState(this.state.id);
            })
            .catch(err => console.log(err));
    }

    render(){
        return <Form onSubmit={this.state.user ? this.submitEdit : this.submitNew}>
            <FormGroup>
                <Label for="name">Name:</Label>
                <input type="text" name="name" onChange={this.onChange} value={this.state.name === '' ? '' : this.state.name}/>
            </FormGroup>
            <FormGroup>
                <Label for="email">Email:</Label>
                <input type="email" name="email" onChange={this.onChange} value={this.state.email === '' ? '' : this.state.email}/>
            </FormGroup>
            <FormGroup>
                <Label for="document">Document:</Label>
                <input type="text" name="document" onChange={this.onChange} value={this.state.document === '' ? '' : this.state.document}/>
            </FormGroup>
            <FormGroup>
                <Label for="phone">Phone:</Label>
                <input type="text" name="phone" onChange={this.onChange} value={this.state.phone === '' ? '' : this.state.phone}/>
            </FormGroup>
            <Button>Send</Button>
        </Form>;
    }
}

export default RegistrationForm;