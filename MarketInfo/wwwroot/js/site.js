const uri = 'api';
let companies = [];
let currentCompanyId;

function getCompanies() {
  fetch(`${uri}/company`)
    .then(response => response.json())
    .then(data => _displayCompanies(data))
    .catch(error => console.error('Unable to get Companies.', error));
}

function getOrders() {
  if (currentCompanyId != null) {
    fetch(`${uri}/orders/${currentCompanyId}`)
      .then(response => response.json())
      .then(data => _displayOrders(data))
      .catch(error => console.error('Unable to get Orders.', error));
  }
}

function getOrdersWithEmployees() {
  if (currentCompanyId != null) {
    fetch(`${uri}/orders/${currentCompanyId}/withemployees`)
      .then(response => response.json())
      .then(data => _displayNotes(data))
      .catch(error => console.error('Unable to get Orders with Employees.', error));
  }
}

function getEmployees() {
  if (currentCompanyId != null) {
    fetch(`${uri}/employees/${currentCompanyId}`)
      .then(response => response.json())
      .then(data => _displayEmployees(data))
      .catch(error => console.error('Unable to get Employees.', error));
  }
}

function getEmployee(id) {
  if (currentCompanyId != null) {
    fetch(`${uri}/employees/${currentCompanyId}/${id}`)
      .then(response => response.json())
      .then(data => _editEmployee(data))
      .catch(error => console.error('Unable to get Employee.', error));
  }
}

function addCompany() {
  const addNameTextbox = document.getElementById('add-name');

  const item = {
    name: addNameTextbox.value.trim()
  };

  fetch(`${uri}/company`, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
    .then(response => response.json())
    .then(() => {
      getCompanies();
      addNameTextbox.value = '';
    })
    .catch(error => console.error('Unable to add Company.', error));
  toggleAddForm();
}

function addEmployee() {
  const firstNameInput = document.getElementById('firstNameInput');
  const lastNameInput = document.getElementById('lastNameInput');
  const titleInput = document.getElementById('titleInput');
  const birthDateInput = document.getElementById('birthDateInput');
  const positionInput = document.getElementById('positionInput');

  const item = {
    firstName: firstNameInput.value.trim(),
    lastName: lastNameInput.value.trim(),
    title: titleInput.value.trim(),
    birthDate: new Date(Date.parse(birthDateInput.value.trim())),
    position: positionInput.value.trim(),
    companyId: currentCompanyId
  };

  fetch(`${uri}/employees`, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
    .then(response => response.json())
    .then(() => getEmployees())
    .catch(error => console.error('Unable to add Employee.', error));
}

function deleteCompany(id) {
  fetch(`${uri}/company/${id}`, {
    method: 'DELETE'
  })
    .then(() => {
      getCompanies();
      _hideDetails();
    })
    .catch(error => console.error('Unable to delete Company.', error));
}

function deleteEmployee(id) {
  fetch(`${uri}/employees/${id}`, {
    method: 'DELETE'
  })
    .then(() => getEmployees())
    .catch(error => console.error('Unable to delete Employee.', error));
}

function toggleAddForm() {
  let addForm = document.getElementById('addForm');
  if (addForm.classList.contains('hidden'))
    addForm.classList.remove('hidden');
  else
    addForm.classList.add('hidden');
}

function updateCompany() {
  const companyId = document.getElementById('idInput').value;
  const company = {
    id: parseInt(companyId, 10),
    name: document.getElementById('nameInput').value.trim(),
    city: document.getElementById('cityInput').value.trim(),
    state: document.getElementById('stateInput').value.trim(),
    phone: document.getElementById('phoneInput').value.trim(),
    address: document.getElementById('addressInput').value.trim()
  };

  fetch(`${uri}/company/${companyId}`, {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(company)
  })
    .then(() => getCompanies())
    .catch(error => console.error('Unable to update Company.', error));

  closeInput();

  return false;
}

function updateEmployee(id) {
  const firstNameInput = document.getElementById('firstNameInput');
  const lastNameInput = document.getElementById('lastNameInput');
  const titleInput = document.getElementById('titleInput');
  const birthDateInput = document.getElementById('birthDateInput');
  const positionInput = document.getElementById('positionInput');

  const employee = {
    id: id,
    firstName: firstNameInput.value.trim(),
    lastName: lastNameInput.value.trim(),
    title: titleInput.value.trim(),
    birthDate: new Date(Date.parse(birthDateInput.value.trim())),
    position: positionInput.value.trim(),
    companyId: currentCompanyId
  };

  fetch(`${uri}/employees/${id}`, {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(employee)
  })
    .then(() => getEmployees())
    .catch(error => console.error('Unable to update Employee.', error));

  return false;
}

function getDetails(id) {
  fetch(`${uri}/company/${id}`)
    .then(response => response.json())
    .then(data => _displayDetails(data))
    .catch(error => console.error('Unable to get Company Details.', error));

  return false;
}

function _displayCompanies(data) {
  const tBody = document.getElementById('companies');
  tBody.innerHTML = '';

  if (Array.isArray(data)) {
    data.forEach(item => {
      let tr = tBody.insertRow();

      let td1 = tr.insertCell(0);
      let nameNode = document.createElement('a');
      nameNode.setAttribute('id', item.id);
      nameNode.innerHTML = item.name;
      nameNode.addEventListener('click', () => getDetails(item.id), false);
      td1.appendChild(nameNode);

      let td2 = tr.insertCell(1);
      let cityNode = document.createTextNode(item.city);
      td2.appendChild(cityNode);

      let td3 = tr.insertCell(2);
      let stateNode = document.createTextNode(item.state);
      td3.appendChild(stateNode);

      let td4 = tr.insertCell(3);
      let phoneNode = document.createTextNode(item.phone);
      td4.appendChild(phoneNode);
    });
    companies = data;
  }
}

function _displayDetails(company) {
  if (company != undefined) { 
    currentCompanyId = company.Id;
    const header = document.getElementById('company-name-header');
    header.innerHTML = company.Name;
    const container = document.getElementById('details');
    container.innerHTML = '';

    let idLabelNode = document.createElement('label');
    idLabelNode.setAttribute('for', 'idInput');
    idLabelNode.classList.add('label');
    idLabelNode.innerHTML = 'Id';
    container.appendChild(idLabelNode);

    let idNode = document.createElement('input');
    idNode.setAttribute('type', 'text');
    idNode.setAttribute('id', 'idInput');
    idNode.classList.add('input');
    idNode.value = company.Id;
    container.appendChild(idNode);

    let nameLabelNode = document.createElement('label');
    nameLabelNode.setAttribute('for', 'nameInput');
    nameLabelNode.classList.add('label');
    nameLabelNode.innerHTML = 'Name';
    container.appendChild(nameLabelNode);

    let nameNode = document.createElement('input');
    nameNode.setAttribute('type', 'text');
    nameNode.setAttribute('id', 'nameInput');
    nameNode.classList.add('input');
    nameNode.value = company.Name;
    container.appendChild(nameNode);

    let addressLabelNode = document.createElement('label');
    addressLabelNode.setAttribute('for', 'addressInput');
    addressLabelNode.classList.add('label');
    addressLabelNode.innerHTML = 'Address';
    container.appendChild(addressLabelNode);

    let addressNode = document.createElement('input');
    addressNode.setAttribute('type', 'text');
    addressNode.setAttribute('id', 'addressInput');
    addressNode.classList.add('input');
    addressNode.value = company.Address;
    container.appendChild(addressNode);

    let phoneLabelNode = document.createElement('label');
    phoneLabelNode.setAttribute('for', 'phoneInput');
    phoneLabelNode.classList.add('label');
    phoneLabelNode.innerHTML = 'Phone';
    container.appendChild(phoneLabelNode);

    let phoneNode = document.createElement('input');
    phoneNode.setAttribute('type', 'text');
    phoneNode.setAttribute('id', 'phoneInput');
    phoneNode.classList.add('input');
    phoneNode.value = company.Phone;
    container.appendChild(phoneNode);

    let cityLabelNode = document.createElement('label');
    cityLabelNode.setAttribute('for', 'cityInput');
    cityLabelNode.classList.add('label');
    cityLabelNode.innerHTML = 'City';
    container.appendChild(cityLabelNode);

    let cityNode = document.createElement('input');
    cityNode.setAttribute('type', 'text');
    cityNode.setAttribute('id', 'cityInput');
    cityNode.classList.add('input');
    cityNode.value = company.City;
    container.appendChild(cityNode);

    let stateLabelNode = document.createElement('label');
    stateLabelNode.setAttribute('for', 'stateInput');
    stateLabelNode.classList.add('label');
    stateLabelNode.innerHTML = 'State';
    container.appendChild(stateLabelNode);

    let stateNode = document.createElement('input');
    stateNode.setAttribute('type', 'text');
    stateNode.setAttribute('id', 'stateInput');
    stateNode.classList.add('input');
    stateNode.value = company.State;
    container.appendChild(stateNode);

    const wrapper = document.getElementById('details-wrapper');
    wrapper.classList.remove('hidden');
    wrapper.classList.add('details-wrapper');
    getOrders();
    getOrdersWithEmployees();
    getEmployees();

    const deleteButton = document.getElementById('deleteCompanyBtn');
    deleteButton.classList.remove('hidden');
    deleteButton.setAttribute('onclick', `deleteCompany(${company.Id})`);
  }
}

function _displayOrders(data) {
  const tBody = document.getElementById('orders');
  tBody.innerHTML = '';

  if (Array.isArray(data)) { 
    data.forEach(item => {
      let tr = tBody.insertRow();

      let td1 = tr.insertCell(0);
      let date = new Date(Date.parse(item.orderDate));
      let dateNode = document.createTextNode(`${date.getMonth()}/${date.getDate()}/${date.getFullYear()}`);
      td1.appendChild(dateNode);

      let td2 = tr.insertCell(1);
      let cityNode = document.createTextNode(item.storeCity);
      td2.appendChild(cityNode);
    });
  }
}

function _displayNotes(data) {
  const tBody = document.getElementById('notes');
  tBody.innerHTML = '';

  if (Array.isArray(data)) {
    data.forEach(item => {
      let tr = tBody.insertRow();

      let td1 = tr.insertCell(0);
      let invoiceNode = document.createTextNode(item.invoiceNumber);
      td1.appendChild(invoiceNode);

      let td2 = tr.insertCell(1);
      let employeeNode = document.createTextNode(`${item.employeeFirstName} ${item.employeeLastName}`);
      td2.appendChild(employeeNode);
    });
  }
}

function _displayEmployees(data) {
  const tBody = document.getElementById('employees');
  tBody.innerHTML = '';

  if (Array.isArray(data)) {
    data.forEach(item => {
      let tr = tBody.insertRow();

      let td1 = tr.insertCell(0);
      let firstNameNode = document.createElement('a');
      firstNameNode.innerHTML = item.firstName;
      firstNameNode.addEventListener('click', () => getEmployee(item.id), false);
      td1.appendChild(firstNameNode);

      let td2 = tr.insertCell(1);
      let lastNameNode = document.createTextNode(item.lastName);
      td2.appendChild(lastNameNode);
    });
  }
  _clearEmployeeForm();
}

function _editEmployee(employee) {
  if (employee != undefined) {
    const firstNameInput = document.getElementById('firstNameInput');
    firstNameInput.value = employee.firstName;
    const lastNameInput = document.getElementById('lastNameInput');
    lastNameInput.value = employee.lastName;
    const titleInput = document.getElementById('titleInput');
    titleInput.value = employee.title;
    const birthDate = new Date(Date.parse(employee.birthDate));
    const birthDateInput = document.getElementById('birthDateInput');
    const day = ("0" + birthDate.getDate()).slice(-2);
    const month = ("0" + (birthDate.getMonth() + 1)).slice(-2);
    birthDateInput.value = `${birthDate.getFullYear()}-${month}-${day}`;
    const positionInput = document.getElementById('positionInput');
    positionInput.value = employee.position;

    const employeeForm = document.getElementById('employeeForm');
    employeeForm.setAttribute('onsubmit', `updateEmployee(${employee.id})`);

    const deleteButton = document.getElementById('deleteEmployeeBtn');
    deleteButton.classList.remove('hidden');
    deleteButton.setAttribute('onclick', `deleteEmployee(${employee.id})`);
  }
}

function _clearEmployeeForm() {
  const firstNameInput = document.getElementById('firstNameInput');
  const lastNameInput = document.getElementById('lastNameInput');
  const titleInput = document.getElementById('titleInput');
  const birthDateInput = document.getElementById('birthDateInput');
  const positionInput = document.getElementById('positionInput');
  const deleteButton = document.getElementById('deleteEmployeeBtn');
  const employeeForm = document.getElementById('employeeForm');

  firstNameInput.value = '';
  lastNameInput.value = '';
  titleInput.value = '';
  birthDateInput.value = '';
  positionInput.value = '';
  deleteButton.classList.add('hidden');
  employeeForm.setAttribute('onsubmit', 'addEmployee()');
}

function _hideDetails() {
  const wrapper = document.getElementById('details-wrapper');
  wrapper.classList.add('hidden');
  wrapper.classList.remove('details-wrapper');

  const deleteButton = document.getElementById('deleteCompanyBtn');
  deleteButton.classList.add('hidden');

  const header = document.getElementById('company-name-header');
  header.innerHTML = '';
}