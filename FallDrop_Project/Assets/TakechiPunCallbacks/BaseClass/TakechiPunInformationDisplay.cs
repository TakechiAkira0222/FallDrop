using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

using TakechiPunCallbacks.CustomProperties;

namespace TakechiPunCallbacks.InformationDisplay
{
    public class TakechiPunInformationDisplay : TakechiPunCustomProperties
    {
        #region RoomInformation

        /// <summary>
        /// Room����\�����܂��B
        /// </summary>
        /// <remarks>
        /// Room���̃v���C���[�̐���N���C�A���g�̖��O�Ȃǂ�PhotnNetwork���Ȃ�ǂ�����ł��擾���\���ł��܂��B
        /// </remarks>
        public void RoomInformationDisplay()
        {
            if (PhotonNetwork.InRoom)
            {
                Debug.Log(InformationTitleTemplate("RoomInformation") + RoomInformationDisplayContents());
            }
            else
            {
                Debug.LogWarning(" Debug is not shown because it is not connected to the room.");
            }
        }

        /// <summary>
        /// Room����\�����܂��B���J�X�^���v���p�e�B�[�̌��̎Q�Ɛݒ肠��
        /// </summary>
        /// <remarks>
        /// Room���̃v���C���[�̐���A�N���C�A���g�̖��O�Ȃǂ��A�����̒��Ȃ�ǂ�����ł��擾���\���ł��܂��B
        /// </remarks>
        /// <param name="customRoomPropertieKeyNames"> �����̃J�X�^���v���p�e�B�[Key���擾���Ē��g��\�����܂��B</param>
        public void RoomInformationDisplay(string[] customRoomPropertieKeyNames)
        {
            if (PhotonNetwork.InRoom)
            {
                Debug.Log(InformationTitleTemplate("RoomInformation") + RoomInformationDisplayContents(customRoomPropertieKeyNames), this.gameObject);
            }
            else
            {
                Debug.LogWarning(" Debug is not shown because it is not connected to the room.");
            }
        }

        /// <summary>
        /// Room����\�����܂��B
        /// </summary>
        /// <remarks>
        /// RoomInfo���擾�\�̏ꍇ�A�g�����Ƃ��ł��܂��B
        /// </remarks>
        public void RoomInformationDisplay( RoomInfo roomInfo)
        {
            if (PhotonNetwork.InRoom)
            {
                Debug.Log(InformationTitleTemplate("RoomInformation") + RoomInformationDisplayContents(roomInfo), this);
            }
            else
            {
                Debug.LogWarning(" Debug is not shown because it is not connected to the room.");
            }
        }

        /// <summary>
        /// Room����\�����܂��B���J�X�^���v���p�e�B�[�̌��̎Q�Ɛݒ肠��
        /// </summary>
        /// <remarks>
        /// RoomInfo���擾�\�̏ꍇ�A�g�����Ƃ��ł��܂��B
        /// </remarks>
        /// <param name="roomInfo"> �����̏�� </param>
        /// <param name="customRoomPropertieKeyNames"> �����̃J�X�^���v���p�e�B�[Key���擾���Ē��g��\�����܂��B</param>
        public void RoomInformationDisplay(RoomInfo roomInfo, string[] customRoomPropertieKeyNames)
        {
            if ( PhotonNetwork.InRoom)
            {
                Debug.Log(InformationTitleTemplate("RoomInformation") + RoomInformationDisplayContents(roomInfo, customRoomPropertieKeyNames), this);
            }
            else
            {
                Debug.LogWarning(" Debug is not shown because it is not connected to the room.");
            }
        }

        #endregion

        #region PlayerInformation

        /// <summary>
        /// �v���C���[�̏����f�o�b�N���O�ɕ\�����܂��B
        /// </summary>
        /// <param name="player"> �v���C���[��� </param>
        /// <param name="playerState"> �Ăяo�����̊֐����@</param>
        protected void PlayerInformationDisplay( Player player, string playerState)
        {
            Debug.Log( InformationTitleTemplate(playerState) + WhatPlayerInformationIsDisplayedInTheDebugLog(player) , this);
        }

        /// <summary>
        /// �v���C���[�̏����f�o�b�N���O�ɕ\�����܂��B ���J�X�^���v���p�e�B�[�̌��̎Q�Ɛݒ肠��
        /// </summary>
        /// <param name="player"> �v���C���[��� </param>
        /// <param name="playerState">�@�v���C���[�̏�� </param>
        /// <param name="functionName"> �Ăяo�����̊֐����@</param>
        /// <returns>
        /// �J�X�^���v���p�e�B�[�̖��O���擾���Ē��g��\�����܂��B
        /// </returns>
        protected void PlayerInformationDisplay( Player player, string playerState, string[] customPropertieKeyNames)
        {
            Debug.Log( InformationTitleTemplate(playerState) + WhatPlayerInformationIsDisplayedInTheDebugLog( player , customPropertieKeyNames), this);
        }

        #endregion

        #region RoomInfoAndPlayerInfoDisplay

        /// <summary>
        /// �����̏��ƕ����ɐڑ����Ă���v���C���[�̏���\�����܂��B
        /// </summary>
        /// <remarks>
        /// Room���̃v���C���[�̐���A�N���C�A���g�̖��O�Ȃǂ��A�����̒��Ȃ�ǂ�����ł��擾���\���ł��܂��B
        /// </remarks>
        public void RoomInfoAndJoinedPlayerInfoDisplay()
        {
            if (PhotonNetwork.InRoom)
            {
                Debug.Log(InformationTitleTemplate("RoomInformation") + RoomInformationDisplayContents());

                foreach (var player in PhotonNetwork.PlayerList)
                {
                    PlayerInformationDisplay(player, $"Player <color=blue>{player.ActorNumber}</color> Information");
                }
            }
            else
            {
                Debug.LogWarning(" Debug is not shown because it is not connected to the room.");
            }
        }

        /// <summary>
        /// �����̏��ƕ����ɐڑ����Ă���v���C���[�̏���\�����܂��B
        /// </summary>
        /// <remarks>
        /// Room���̃v���C���[�̐���A�N���C�A���g�̖��O�Ȃǂ��A�����̒��Ȃ�ǂ�����ł��擾���\���ł��܂��B
        /// </remarks>
        public void RoomInfoAndJoinedPlayerInfoDisplay(string[] customRoomPropertieKeyNames)
        {
            if (PhotonNetwork.InRoom)
            {
                Debug.Log(InformationTitleTemplate("RoomInformation") + RoomInformationDisplayContents(customRoomPropertieKeyNames));

                foreach (var player in PhotonNetwork.PlayerList)
                {
                    PlayerInformationDisplay(player, $"Player <color=blue>{player.ActorNumber}</color> Information");
                }
            }
            else
            {
                Debug.LogWarning(" Debug is not shown because it is not connected to the room.");
            }
        }

        /// <summary>
        /// �����̏��ƁA�����ɐڑ����Ă���v���C���[�̏���\�����܂��B���J�X�^���v���p�e�B�[�̌��̎Q�Ɛݒ肠��
        /// </summary>
        /// <remarks>
        /// Room���̃v���C���[�̐���A�N���C�A���g�̖��O�Ȃǂ��A�����̒��Ȃ�ǂ�����ł��擾���\���ł��܂��B
        /// </remarks>
        /// <param name="customRoomPropertieKeyNames"> ������ RoomCustomPropetieKey ���擾���Ē��g��\�����܂��B</param>
        /// <param name="customPlayerPropertieKeyNames"> �����̂ɂ���character�́@PlayerCustomPropetieKey���A�擾���Ē��g��\�����܂��B</param>
        public void RoomInfoAndJoinedPlayerInfoDisplay(string[] customRoomPropertieKeyNames, string[] customPlayerPropertieKeyNames)
        {
            if (PhotonNetwork.InRoom)
            {
                Debug.Log(InformationTitleTemplate("RoomInformation") + RoomInformationDisplayContents(customRoomPropertieKeyNames), this.gameObject);

                foreach (var player in PhotonNetwork.PlayerList)
                {
                    PlayerInformationDisplay(player, $"Player <color=blue>{player.ActorNumber}</color> Information", customPlayerPropertieKeyNames);
                }
            }
            else
            {
                Debug.LogWarning(" Debug is not shown because it is not connected to the room.");
            }
        }

        #endregion
        
        #region InformationTitle

        /// <summary>
        /// ���̕\��̃e���v���[�g �̐ݒ�
        /// </summary>
        /// <param name="titleName"> �f�o�b�N�̕\�薼 </param>
        /// <returns></returns>
        protected string InformationTitleTemplate(string titleName)
        {
            return $" { titleName} \n" + " <color=blue>Info</color> \n";
        }

        #endregion

        #region private roomInfo function

        /// <summary>
        /// Room�����f�o�b�N���O�ɕ\��������e�̐ݒ�
        /// </summary>
        /// <param name="roomInfo"> ���[���̏�� </param>
        /// <returns>
        /// RoomInfo�@�ŎQ�Ƃ���ꍇ���̊֐����g�p���Ă��������B
        /// </returns>
        private string RoomInformationDisplayContents(RoomInfo roomInfo)
        {
            return
                $" roomName : <color=green>{roomInfo.Name}</color> \n" +
                $" masterClientId : <color=green>{roomInfo.masterClientId}</color> \n" +
                $" PlayerCount : <color=green>{roomInfo.PlayerCount} / {roomInfo.MaxPlayers}</color> \n" +
                $" CustomProperties : <color=green>{roomInfo.CustomProperties}</color> \n" +
                $" Open : <color=green>{roomInfo.IsOpen}</color> \n" +
                $" Visible : <color=green>{roomInfo.IsVisible}</color> \n" +
                $" roomInfo : <color=green>{roomInfo}</color> \n";
        }

        /// <summary>
        /// Room�����f�o�b�N���O�ɕ\��������e�̐ݒ� ���J�X�^���v���p�e�B�[�̌��̎Q�Ɛݒ肠��
        /// </summary>
        /// <param name="roomInfo"> ���[���̏�� </param>
        /// <returns>
        /// RoomInfo�@�ŎQ�Ƃ���ꍇ���̊֐����g�p���Ă��������B
        /// </returns>
        private string RoomInformationDisplayContents(RoomInfo roomInfo, string[] customPropertieKeyNames)
        {
            string s = RoomInformationDisplayContents(roomInfo);

            foreach (string propertie in customPropertieKeyNames)
            {
                s += $" CurrentRoom {propertie} : <color=green>{PhotonNetwork.CurrentRoom.CustomProperties[propertie]}</color> \n";
            }

            return s;
        }

        /// <summary>
        /// Room�����f�o�b�N���O�ɕ\��������e�̐ݒ�
        /// </summary>
        /// <returns>
        /// PhotonNetwork �͈����ł̎Q�Ƃ��ł��܂���B
        /// ��PhotonNetwork���Q�Ɖ\�ȏꏊ�ł���΂ǂ�����ł��Ăяo�����Ƃ��ł��܂��B
        /// </returns>
        private string RoomInformationDisplayContents()
        {
            return
               $" PlayerSlots : <color=green>{PhotonNetwork.CurrentRoom.PlayerCount} / {PhotonNetwork.CurrentRoom.MaxPlayers}</color> \n" +
               $" RoomName : <color=green>{PhotonNetwork.CurrentRoom.Name}</color> \n" +
               $" IsOpen : <color=green>{PhotonNetwork.CurrentRoom.IsOpen}</color> \n" +
               $" IsVisible : <color=green>{PhotonNetwork.CurrentRoom.IsVisible}</color> \n" +
               $" HostName : <color=green>{PhotonNetwork.MasterClient.NickName}</color> \n" +
               $" MyPlayerID : <color=green>{PhotonNetwork.LocalPlayer.ActorNumber}</color> \n" +
               $" AutomaticallySyncScene : <color=green>{PhotonNetwork.AutomaticallySyncScene}</color> \n";
        }

        /// <summary>
        /// Room�����f�o�b�N���O�ɕ\��������e�̐ݒ� ���J�X�^���v���p�e�B�[�̌��̎Q�Ɛݒ肠��
        /// </summary>
        /// <returns>
        /// PhotonNetwork �͈����ł̎Q�Ƃ��ł��܂���B
        /// ��PhotonNetwork���Q�Ɖ\�ȏꏊ�ł���΂ǂ�����ł��Ăяo�����Ƃ��ł��܂�
        /// �܂��A�J�X�^���v���p�e�B�[�̖��O���擾���Ē��g��\�����܂��B
        /// </returns>
        private string RoomInformationDisplayContents(string[] customPropertieKeyNames)
        {
            string s = RoomInformationDisplayContents();

            foreach (string propertie in customPropertieKeyNames)
            {
                s += $" CurrentRoom {propertie} : <color=green>{PhotonNetwork.CurrentRoom.CustomProperties[propertie]}</color> \n";
            }

            return s;
        }

        #endregion

        #region private roominfo finction

        /// <summary>
        /// �v���C���[�̏����f�o�b�N���O�ɕ\��������e�̐ݒ�
        /// </summary>
        /// <param name="player"> �v���C���[��� </param>
        /// <returns>
        /// �v���C���[�̏����f�o�b�N���O�ɕ\�����������e�𕶎���Ƃ��ĕԂ��܂��B
        /// </returns>
        private string WhatPlayerInformationIsDisplayedInTheDebugLog(Photon.Realtime.Player player)
        {
            return
               $" ActorNumber : <color=green>{player.ActorNumber}</color> \n" +
               $" NickName : <color=green>{player.NickName}</color> \n" +
               $" IsMasterClient : <color=green>{player.IsMasterClient}</color> \n" +
               $" IsLocal : <color=green>{player.IsLocal}</color>\n" +
               $" TagObject : <color=green>{player.TagObject}</color>\n";
        }

        /// <summary>
        /// �v���C���[�̏����f�o�b�N���O�ɕ\��������e�̐ݒ� ���J�X�^���v���p�e�B�[�̌��̎Q�Ɛݒ肠��
        /// </summary>
        /// <param name="player"> �v���C���[��� </param>
        /// <returns>
        /// �v���C���[�̏����f�o�b�N���O�ɕ\�����������e�𕶎���Ƃ��ĕԂ��܂��B
        /// �J�X�^���v���p�e�B�[�̖��O���擾���Ē��g��\�����܂��B
        /// </returns>
        private string WhatPlayerInformationIsDisplayedInTheDebugLog(Photon.Realtime.Player player, string[] customPropertieKeyNames)
        {
            string s = WhatPlayerInformationIsDisplayedInTheDebugLog(player);

            foreach (string propertie in customPropertieKeyNames)
            {
                s += $" Player {propertie} : <color=green>{player.CustomProperties[propertie]}</color> \n";
            }

            return s;
        }

        #endregion

    }
}
