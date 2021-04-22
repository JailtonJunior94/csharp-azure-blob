output "connection_azure_poc_blob" {
  value = nonsensitive(azurerm_storage_account.azure_poc_blob.primary_blob_connection_string)
}
