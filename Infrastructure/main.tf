terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=2.56.0"
    }
  }
}

provider "azurerm" {
  features {}
  subscription_id = var.subscriptionid
}

resource "azurerm_resource_group" "azure_blob_rg" {
  name     = "azure-blob-rg"
  location = var.location
}

resource "azurerm_storage_account" "azure_poc_blob" {
  name                = "aopastorage"
  resource_group_name = azurerm_resource_group.azure_blob_rg.name
  location            = azurerm_resource_group.azure_blob_rg.location

  account_tier              = "Standard"
  account_kind              = "StorageV2"
  account_replication_type  = "LRS"
  enable_https_traffic_only = true
  access_tier               = "Hot"
  allow_blob_public_access  = true
}

resource "azurerm_storage_container" "aopa_container" {
  name                  = "contestacoes"
  storage_account_name  = azurerm_storage_account.azure_poc_blob.name
  container_access_type = "blob"
}
