using Microsoft.AspNetCore.Components;
using MudBlazor;
using Mc2.CrudTest.Presentation.Client.Models.Customers;
using Mc2.CrudTest.Presentation.Shared.Extensions;

namespace Mc2.CrudTest.Presentation.Client.Pages.Catalog
{
    public partial class Customers
    {
        [Inject] private HttpClient _httpClient { get; set; }
        private List<CustomerDTO> _cutomerList = new();

        private bool _dense = false;
        private bool _striped = true;
        private bool _bordered = false;

        private bool _loaded = false;

        protected override async Task OnInitializedAsync()
        {
            await GetCustomersAsync();
            _loaded = true;
        }

        private async Task GetCustomersAsync()
        {
            var response = await _httpClient.GetAsync("/api/Customer/GetAll");
            var result = await response.ToResult<List<CustomerDTO>>();
            if (result.Succeeded)
            {
                _cutomerList = result.Data.ToList();
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private async Task Delete(int id)
        {
            _loaded = false;
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<BlazorHero.CleanArchitecture.Client.Shared.DeleteConfirmation>("Delete", options);
            var resultDisalog = await dialog.Result;
            if (!resultDisalog.Cancelled)
            {
                var response = await _httpClient.DeleteAsync($"/api/Customer/Delete/{id}");
                var result = await response.ToResult();
                if (result.Succeeded)
                {
                    await GetCustomersAsync();
                    _loaded = false;
                    _snackBar.Add(result.Messages[0], Severity.Success);
                }
                else
                {
                    foreach (var message in result.Messages)
                    {
                        _snackBar.Add(message, Severity.Error);
                    }
                }
            }

        }

        private async Task InvokeCreateModal()
        {
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddCustomer>("Create", options);
            await dialog.Result;
            await GetCustomersAsync();
        }

        private async Task InvokeEditModal(int id)
        {
            var modalParams = new DialogParameters();
            var response = await _httpClient.GetAsync($"/api/Customer/GetById/{id}");
            var customerResult = await response.ToResult<UpdateCustomerDTO>();
            if(!customerResult.Succeeded)
            {
                foreach (var message in customerResult.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
                return;
            }
            modalParams.Add(nameof(EditCustomer._updateCustomerDTOModel), customerResult.Data);

            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<EditCustomer>("Edit", modalParams, options);
            await dialog.Result;
            await GetCustomersAsync();

        }
    }
}